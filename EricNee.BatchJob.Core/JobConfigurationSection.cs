using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public class JobConfigurationSection : ConfigurationSection
    {
        public static IEnumerable<Job> GetJobs()
        {
            var jobs = ((JobConfigurationSection)ConfigurationManager.GetSection("BatchJob")).Jobs;
            var rt = new List<Job>(jobs.Count);
            foreach (var job in jobs)
            {
                var jobData = (JobItemData)job;
                rt.Add(new Job() { JobId = jobData.JobId, JobName = jobData.JobName, JobDetail = new JobDetail() { AssemblyName = jobData.JobAssemblyName, JobFullName = jobData.JobTypeFullName }, Cron = jobData.Cron });

            }
            return rt;
        }

        [ConfigurationProperty("Jobs")]
        public JobsData Jobs { get { return (JobsData)this["Jobs"]; } set { this["Jobs"] = value; } }
    }
}
