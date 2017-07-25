using E08_MilitaryElite.Models;
using System.Collections.Generic;

namespace E08_MilitaryElite.Interfaces
{
    public interface IEngineer: ISpecialisedSoldier
    {
        IList<IRepair> Repairs { get; }
    }
}