using E09_CollectionHierarchy.Interfaces;
using System;

namespace E09_CollectionHierarchy.Models
{
    public class MyCollection : AddRemoveCollection, ICountable
    {
        public MyCollection() : base()
        { }

        public int Used
        {
            get { return this.Collection.Count; }
        }

        public override string Remove()
        {
            if (this.Used == 0)
            {
                throw new ArgumentException("Empty collection!");
            }
            var indexToRemove = 0;
            var elementToRemove = this.Collection[indexToRemove];
            this.Collection.RemoveAt(indexToRemove);
            return elementToRemove;
        }
    }
}
