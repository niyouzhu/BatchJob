using EricNee.BatchJob.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EricNee.BatchJob.Scheduler
{
    public interface IScheduler
    {
        Task Run();
        void Stop();

    }
}
