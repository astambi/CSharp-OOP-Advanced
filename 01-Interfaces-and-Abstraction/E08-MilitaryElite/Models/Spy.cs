using E08_MilitaryElite.Interfaces;
using System.Text;

namespace E08_MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber
        {
            get { return this.codeNumber; }
            private set { this.codeNumber = value; }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder
                .AppendLine(base.ToString())
                .AppendLine($"Code Number: {this.CodeNumber}");

            return builder.ToString().Trim();
        }
    }
}
