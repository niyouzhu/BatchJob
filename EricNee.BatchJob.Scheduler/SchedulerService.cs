using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace EricNee.BatchJob.Scheduler
{
    public partial class SchedulerService : ServiceBase
    {
        public SchedulerService()
        {
            InitializeComponent();
        }

        App App { get; } = new App();
        protected override void OnStart(string[] args)
        {
            App.Run();
        }

        protected override void OnStop()
        {
            App.Stop();
        }
    }
}
