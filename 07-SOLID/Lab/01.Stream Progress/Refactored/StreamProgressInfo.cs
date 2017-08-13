namespace _01.Stream_Progress.Refactored
{
    public class StreamProgressInfo
    {
        private IStreamable streamFile;

        public StreamProgressInfo(IStreamable streamFile)
        {
            this.streamFile = streamFile;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamFile.BytesSent * 100) / this.streamFile.Length;
        }
    }
}