using RecyclingStation.BusinessLayer.Contracts.IO;
using System;
using System.Text;

namespace RecyclingStation.BusinessLayer.IO
{
    public class ConsoleWriter : IWriter
    {
        private StringBuilder outputGatherer;

        public ConsoleWriter()
            : this(new StringBuilder())
        {
        }

        public ConsoleWriter(StringBuilder outputGatherer)
        {
            this.outputGatherer = outputGatherer;
        }

        public void GatherOutput(string outputToGather)
        {
            this.outputGatherer.AppendLine(outputToGather);
        }

        public void WriteGatheredOutput()
        {
            Console.WriteLine(this.outputGatherer.ToString().Trim());
        }
    }
}
