namespace RecyclingStation.BusinessLayer.Contracts.IO
{
    public interface IWriter
    {
        void GatherOutput(string outputToGather);

        void WriteGatheredOutput();
    }
}
