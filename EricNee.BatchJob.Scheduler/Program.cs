using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace EricNee.BatchJob.Scheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                System.Windows.Forms.Application.ThreadException += (o, e) =>
                {
                    new ThreadExceptionDialog(e.Exception).ShowDialog();
                };
                System.Windows.Forms.Application.Run(new SchedulerForm());
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new SchedulerService()
                };
                ServiceBase.Run(ServicesToRun);
            }

        }
    }
}
