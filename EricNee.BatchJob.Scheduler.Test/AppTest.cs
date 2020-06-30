using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EricNee.BatchJob.Scheduler;
using System.Threading;

namespace EricNee.BatchJob.Scheduler.Test
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void TestRun()
        {
            var app = new App();
            app.Run();
            Thread.Sleep(10000000);
        }
    }
}
