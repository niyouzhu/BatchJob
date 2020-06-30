using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EricNee.BatchJob.Scheduler
{
    public class App
    {
        public SchedulerConfigurationSection Section = (SchedulerConfigurationSection)ConfigurationManager.GetSection("Scheduler");

        private IScheduler _scheduler;
        public IScheduler Scheduler
        {
            get
            {
                if (_scheduler == null)
                    _scheduler = new DefaultScheduler(Section, new DefaultSchedulerOptions() { });
                return _scheduler;
            }
        }

        public void Stop()
        {
            Scheduler.Stop();
        }

        public void Run()
        {
            var task = Scheduler.Run();
            task.ContinueWith(t =>
            {

                Trace.WriteLine($"Time:{DateTime.Now};{t.Exception}");
                throw t.Exception.Flatten();
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
