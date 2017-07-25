using E08_MilitaryElite.Interfaces;
using System;

namespace E08_MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string codeName;
        private string state;

        public Mission(string codeName, string state)
        {
            this.codeName = codeName;
            this.State = state;
        }

        public string CodeName => this.codeName;

        public string State
        {
            get { return this.state; }
            private set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("Invalid State!");
                }
                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.state = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
