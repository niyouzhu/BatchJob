using EricNee.BatchJob.Core;
using Quartz.Core;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Quartz
{
    public class QuartzBatchJob : IBatchJob
    {


        public void Run()
        {
            var schedular = StdSchedulerFactory.GetDefaultScheduler();
            schedular.Start();

        }
    }
}
