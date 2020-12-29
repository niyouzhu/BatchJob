using EricNee.BatchJob.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace EricNee.BatchJob.Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Thread.Sleep(20 * 1000);
                if (args.Length == 0)
                {
                    throw new NullReferenceException("Args cannot be empty.");
                }
                var jobManager = new JobManager();
                var job = jobManager.GetJobs().FirstOrDefault(it => string.Equals(it.JobId, args[0], StringComparison.InvariantCultureIgnoreCase));
                if (job == null || job.JobDetail == null)
                {
                    throw new NullReferenceException($"The job id {args[0]} is invalid.");
                }
                Job.CreateBatchJob(job.JobDetail, job).Run();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Time:{DateTime.Now}; {ex}");
            }

        }
    }
}
