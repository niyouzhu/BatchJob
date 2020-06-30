namespace EricNee.BatchJob.Core
{
    public interface IJobSerializer
    {
        IBatchJob Deserialize();
        string Serialize(IBatchJob batchjob);
    }
}