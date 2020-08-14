using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace EricNee.BatchJob.Scheduler.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Foobar().ContinueWith(task => { Debug.WriteLine(task.Exception.InnerException); }, TaskContinuationOptions.OnlyOnFaulted);
            Thread.Sleep(10000);
        }

        private Task Foo()
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    throw new Exception("Foo");
                }
                catch (Exception)
                {
                    throw;
                }


            });
        }

        private Task Bar()
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    throw new Exception("Bar");
                }
                catch (Exception)
                {
                    throw;
                }


            });
        }

        private Task Foobar()
        {
            return Task.Factory.ContinueWhenAny(new[] { Foo(), Bar() }, task =>
            {

                if (task.IsFaulted)
                {
                    Debug.WriteLine("Hello Foobar:" + task.Exception.InnerException);
                    //throw task.Exception.InnerException;
                }
            });
        }
    }
}
