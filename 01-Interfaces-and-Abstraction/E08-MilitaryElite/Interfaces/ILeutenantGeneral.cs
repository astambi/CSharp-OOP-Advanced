using System.Collections.Generic;

namespace E08_MilitaryElite.Interfaces
{
    public interface ILeutenantGeneral: IPrivate
    {
        IList<IPrivate> Privates { get; }
    }
}