using System;
using System.Linq;

namespace E08_CustomListSorter.Models
{
    public class Sorter
    {
        public static CustomList<T> Sort<T>(CustomList<T> list)
            where T : IComparable
        {
            var sortedList = list.Elements
                                 .OrderBy(e => e)
                                 .ToList();
            return new CustomList<T>(sortedList);
        }
    }
}