using E08_MilitaryElite.Interfaces;
using System.Text;

namespace E08_MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        private string id;
        private string firstName;
        private string lastName;

        public Soldier(string id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set { this.lastName = value; }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");

            return builder.ToString().Trim();
        }
    }
}
