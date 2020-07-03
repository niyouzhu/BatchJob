using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public abstract class BatchJobBase : IBatchJob
    {

        public BatchJobBase(Job jobInfo)
        {
            JobInfo = jobInfo;
        }
        public Job JobInfo { get; }
        public abstract void Run();
    }
}
