using E09_CollectionHierarchy.Interfaces;
using System;

namespace E09_CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IRemovable
    {
        public AddRemoveCollection() : base()
        { }

        public override int Add(string element)
        {
            this.Collection.Insert(0, element);
            return 0;
        }

        public virtual string Remove()
        {
            if (this.Collection.Count == 0)
            {
                throw new ArgumentException("Empty collection!");
            }
            var indexToRemove = this.Collection.Count - 1;
            var elementToRemove = this.Collection[indexToRemove];
            this.Collection.RemoveAt(indexToRemove);
            return elementToRemove;
        }
    }
}
