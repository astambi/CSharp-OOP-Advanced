using E09_CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace E09_CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        private List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public List<string> Collection
        {
            get { return this.collection; }
            //protected set { this.collection = value; }
        }

        public virtual int Add(string element)
        {
            this.collection.Add(element);
            return this.collection.Count - 1;
        }
    }
}
