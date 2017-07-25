using System.Collections.Generic;

namespace E08_MilitaryElite.Interfaces
{
    interface ICommando : ISpecialisedSoldier
    {
        IList<IMission> Missions { get; }
    }
}
