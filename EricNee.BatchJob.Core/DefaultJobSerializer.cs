using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public class DefaultJobSerializer : IJobSerializer
    {
        public IBatchJob Deserialize()
        {
            throw new NotImplementedException();
        }

        public string Serialize(IBatchJob batchjob)
        {
            throw new NotImplementedException();
        }
    }
}
