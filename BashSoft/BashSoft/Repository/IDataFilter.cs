using System.Collections.Generic;

namespace BashSoft.Repository
{
    public interface IDataFilter
    {
        void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake);
    }
}
