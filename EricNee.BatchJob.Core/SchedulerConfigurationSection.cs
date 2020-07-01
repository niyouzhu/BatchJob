using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public class SchedulerConfigurationSection : System.Configuration.ConfigurationSection
    {
        [ConfigurationProperty("ExecutorPath")]
        public string ExecutorPath { get { return (string)this["ExecutorPath"]; } set { this["ExecutorPath"] = value; } }
    }
}
