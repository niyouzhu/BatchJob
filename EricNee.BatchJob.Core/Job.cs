using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public class Job
    {
        public string JobName { get; set; }

        public string JobId { get; set; }

        public JobDetail JobDetail { get; set; }

        public string Cron { get; set; }

        public static IBatchJob CreateBatchJob(JobDetail jobDetail, params object[] args)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.FirstOrDefault(it => it.FullName.ToUpperInvariant().Contains(jobDetail.AssemblyName.ToUpperInvariant()));
            if (assembly == null)
                assembly = Assembly.Load(jobDetail.AssemblyName);
            var type = assembly.GetType(jobDetail.JobFullName, true, true);
            if (args == null || args.Length == 0)
                return (IBatchJob)Activator.CreateInstance(type);
            return (IBatchJob)Activator.CreateInstance(type, args);
        }



    }
}
