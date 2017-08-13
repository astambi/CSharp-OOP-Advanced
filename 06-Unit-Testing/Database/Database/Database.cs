using System;
using System.Linq;

namespace Database
{
    public class Database
    {
        private const int MaxCapacity = 16;

        private int[] collection;
        private int collectionCount;

        public Database(int[] elements)
        {
            this.collection = new int[MaxCapacity];
            this.collectionCount = 0;
            this.Collection = elements.ToArray();
        }

        public int Capacity => this.collection.Length;

        public int Count => this.collectionCount;

        private int[] Collection
        {
            get => this.collection;
            set
            {
                if (value.Length > MaxCapacity)
                {
                    throw new InvalidOperationException($"Collection capacity cannot exceed {MaxCapacity}!");
                }

                foreach (var element in value)
                {
                    this.collection[this.collectionCount++] = element;
                }
            }
        }

        public void Add(int element)
        {
            if (this.collectionCount >= MaxCapacity)
            {
                throw new InvalidOperationException($"Cannot add more than {MaxCapacity} elements to the collection!");
            }

            this.collection[this.collectionCount++] = element;
        }

        public void Remove()
        {
            if (this.collectionCount == 0)
            {
                throw new InvalidOperationException($"Cannot remove an element from an empty collection!");
            }

            this.collection[--this.collectionCount] = 0;
        }

        public int[] Fetch()
        {
            if (this.collectionCount == 0)
            {
                return new int[0];
            }

            return this.collection
                       .Take(this.collectionCount)
                       .ToArray();
        }
    }
}
