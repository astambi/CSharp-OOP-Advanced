using System;
using System.Linq;

namespace E09_CustomListIterator.Models
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