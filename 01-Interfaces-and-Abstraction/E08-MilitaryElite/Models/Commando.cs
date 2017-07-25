using E08_MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace E08_MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private IList<IMission> missions;

        public Commando(string id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IList<IMission> Missions => this.missions;

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder
                .AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mission in this.missions)
            {
                builder.AppendLine($"  {mission}");
            }

            return builder.ToString().Trim();
        }
    }
}