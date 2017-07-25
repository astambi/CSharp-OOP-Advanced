using E08_MilitaryElite.Interfaces;
using System.Text;

namespace E08_MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        private double salary;

        public Private(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.salary = salary;
        }

        public double Salary => this.salary;

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder
                .Append(base.ToString())
                .Append($" Salary: {this.Salary:f2}");

            return builder.ToString().Trim();
        }
    }
}
