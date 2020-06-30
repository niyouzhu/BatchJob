using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricNee.BatchJob.Core
{
    public class JobSerialization
    {
        public JobSerialization(IJobSerializer serializer)
        {
            Serializer = serializer;
        }
        public IJobSerializer Serializer { get; }
        public string Serialize(IBatchJob batchjob)
        {
            return Serializer.Serialize(batchjob);
        }


        public IBatchJob Deserialize(string batchJobContent)
        {
            return Serializer.Deserialize();
        }
    }
}
