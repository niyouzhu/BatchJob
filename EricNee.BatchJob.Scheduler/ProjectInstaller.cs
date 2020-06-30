using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace EricNee.BatchJob.Scheduler
{
    [RunInstaller(true)]
    public partial class SchedulerProjectInstaller : System.Configuration.Install.Installer
    {
        public SchedulerProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
