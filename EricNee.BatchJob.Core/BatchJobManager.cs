using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public class JobManager
    {

        public IEnumerable<Job> GetJobs()
        {
            return JobConfigurationSection.GetJobs();
        }
    }
}
