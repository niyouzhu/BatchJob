using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public interface IBatchJob
    {

        Job JobInfo { get; }
        void Run();
    }
}
