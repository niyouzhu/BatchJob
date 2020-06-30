using EricNee.BatchJob.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NCrontab;
using System.Collections.Concurrent;

namespace EricNee.BatchJob.Scheduler
{
    public class DefaultScheduler : IScheduler
    {
        public DefaultScheduler(SchedulerConfigurationSection section, DefaultSchedulerOptions options)
        {
            Section = section;
            Options = options;
        }


        public SchedulerConfigurationSection Section { get; }

        public JobManager JobManager { get; } = new JobManager();

        private IEnumerable<Job> _Jobs;
        private IEnumerable<Job> Jobs
        {
            get
            {

                if (_Jobs == null)
                {
                    _Jobs = JobManager.GetJobs();
                }
                return _Jobs;
            }
        }

        private object _planLock = new object();
        private IEnumerable<SchedulePlan> _Plan;
        private IEnumerable<SchedulePlan> Plan
        {
            get
            {
                if (_Plan != null) return _Plan;
                lock (_planLock)
                {
                    if (_Plan == null)
                    {
                        var plan = new BlockingCollection<SchedulePlan>(Jobs.Count());
                        foreach (var job in Jobs)
                        {
                            var now = DateTime.Now;
                            var cron = CrontabSchedule.TryParse(job.Cron, new CrontabSchedule.ParseOptions() { IncludingSeconds = true });
                            if (cron == null) { throw new CrontabException($"Invalid cron expression {job.Cron}, job id {job.JobId}, job name:{job.JobName}"); }
                            plan.Add(new SchedulePlan() { BaseTime = now, Executed = false, Job = job, NextTime = cron.GetNextOccurrence(now) });
                        }
                        _Plan = plan;
                    }
                }

                return _Plan;
            }
        }


        public DefaultSchedulerOptions Options { get; }


        public Task Run()
        {
            Stopped.Value = false;
            var planTask = Task.Factory.StartNew(state =>
            {
                RefreshPlan((StopClass)state);
            }, Stopped, TaskCreationOptions.LongRunning);
            var workTask = Task.Factory.StartNew(state =>
  {
      Work((StopClass)state);
  }, Stopped, TaskCreationOptions.LongRunning);

            return Task.Factory.ContinueWhenAny(new Task[] { planTask, workTask }, task =>
 {
     if (task.IsFaulted)
         throw task.Exception;
 });
        }


        private SpinWait Waitor { get; } = new SpinWait();

        private class SchedulePlan
        {
            public Job Job { get; set; }
            public DateTime BaseTime { get; set; }

            public DateTime NextTime { get; set; }

            private bool _executed;
            private object _lock = new object();
            public bool Executed
            {
                get
                {
                    lock (_lock)
                    {
                        return _executed;

                    }

                }
                set
                {
                    lock (_lock)
                    {
                        _executed = value;

                    }
                }
            }
        }

        private class StopClass
        {
            public bool Value { get; set; }
        }

        private StopClass Stopped { get; } = new StopClass() { Value = false };

        private void RefreshPlan(StopClass stopped)
        {
            while (!stopped.Value)
            {
                var now = DateTime.Now;
                foreach (var item in Plan)
                {
                    if (item.Executed)
                    {
                        var cron = CrontabSchedule.Parse(item.Job.Cron, new CrontabSchedule.ParseOptions() { IncludingSeconds = true });
                        item.Executed = false;
                        item.NextTime = cron.GetNextOccurrence(now);
                    }
                }
                Waitor.SpinOnce();
            }
        }

        private void Work(StopClass stopped)
        {
            while (!stopped.Value)
            {
                var now = DateTime.Now;
                foreach (var plan in Plan)
                {
                    try
                    {
                        if (plan.NextTime <= now && plan.Executed == false)
                        {
                            plan.Executed = true;
                            var startInfo = new ProcessStartInfo(Section.ExecutorPath, plan.Job.JobId);
                            startInfo.CreateNoWindow = true;
                            startInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            startInfo.UseShellExecute = true;
                            var process = Process.Start(startInfo);
                        }

                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine($"Time:{DateTime.Now};{ex}");
                    }
                }
                if (Waitor.NextSpinWillYield)
                    Waitor.SpinOnce();
            }



        }


        public void Stop()
        {
            Stopped.Value = true;
        }

    }


}
