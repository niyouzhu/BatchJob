using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public class JobItemData : ConfigurationElement
    {
        [ConfigurationProperty("JobId")]
        public string JobId { get { return (string)this["JobId"]; } set { this["JobId"] = value; } }
        [ConfigurationProperty("JobName")]
        public string JobName { get { return (string)this["JobName"]; } set { this["JobName"] = value; } }
        [ConfigurationProperty("TypeFullName")]
        public string JobTypeFullName { get { return (string)this["TypeFullName"]; } set { this["TypeFullName"] = value; } }
        [ConfigurationProperty("AssemblyName")]
        public string JobAssemblyName { get { return (string)this["AssemblyName"]; } set { this["AssemblyName"] = value; } }
        [ConfigurationProperty("Cron")]
        public string Cron { get { return (string)this["Cron"]; } set { this["Cron"] = value; } }
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
