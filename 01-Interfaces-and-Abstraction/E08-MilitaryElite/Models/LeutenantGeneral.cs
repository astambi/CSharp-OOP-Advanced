using E08_MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace E08_MilitaryElite.Models
{
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private IList<IPrivate> privates;

        public LeutenantGeneral(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IList<IPrivate> Privates => this.privates;

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder
                .AppendLine(base.ToString())
                .AppendLine($"Privates:");

            foreach (var priv in this.privates)
            {
                builder.AppendLine($"  {priv}");
            }

            return builder.ToString().Trim();
        }
    }
}