using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public class JobItemData : ConfigurationElement
    {
        [ConfigurationProperty("jobId")]
        public string JobId { get { return (string)base["jobId"]; } set { base["jobId"] = value; } }
        [ConfigurationProperty("jobName")]
        public string JobName { get { return (string)base["jobName"]; } set { base["jobName"] = value; } }
        [ConfigurationProperty("typeFullName")]
        public string JobTypeFullName { get { return (string)base["typeFullName"]; } set { base["typeFullName"] = value; } }
        [ConfigurationProperty("assemblyName")]
        public string JobAssemblyName { get { return (string)base["assemblyName"]; } set { base["assemblyName"] = value; } }
        [ConfigurationProperty("cron")]
        public string Cron { get { return (string)base["cron"]; } set { base["cron"] = value; } }
    }

    public class JobsData : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new JobItemData();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((JobItemData)element).JobId;
        }
    }
}
