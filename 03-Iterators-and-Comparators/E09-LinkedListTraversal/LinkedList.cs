using System.Collections;
using System.Collections.Generic;

namespace E09_LinkedListTraversal
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private List<T> collection;

        public LinkedList()
        {
            this.collection = new List<T>();
        }

        public int Count => this.collection.Count;

        public void Add(T element)
        {
            this.collection.Add(element);
        }

        public bool Remove(T element)
        {
            if (!this.collection.Contains(element))
            {
                return false;
            }

            var firstIndexToRemove = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.collection[i].Equals(element))
                {
                    firstIndexToRemove = i;
                    break;
                }
            }
            this.collection.RemoveAt(firstIndexToRemove);

            return true;
        }

        public IEnumerator<T> GetEnumerator() => this.collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}