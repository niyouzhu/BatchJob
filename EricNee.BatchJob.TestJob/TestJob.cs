using EricNee.BatchJob.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.TestJob
{
    public class TestJob : IBatchJob
    {
        public TestJob(Job jobInfo)
        {
            JobInfo = jobInfo;
        }
        public Job JobInfo
        {
            get;
        }

        public void Run()
        {
            Debug.WriteLine("Hello World!");
            Trace.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            //Console.ReadKey();
        }
    }
}
