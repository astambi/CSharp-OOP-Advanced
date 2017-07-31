using System;
using System.Collections;
using System.Collections.Generic;

namespace E03_Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private IList<T> collection;

        public CustomStack()
        {
            this.collection = new List<T>();
        }

        public void Push(T element)
        {
            this.collection.Add(element);
        }

        public T Pop()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            var lastIndex = this.collection.Count - 1;
            var removedElement = this.collection[lastIndex];
            this.collection.RemoveAt(lastIndex);
            return removedElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.collection.Count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}