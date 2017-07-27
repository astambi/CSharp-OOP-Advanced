using E08_CustomListSorter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_CustomListSorter.Models
{
    public class CustomList<T> : ICustomList<T>
        where T : IComparable
    {
        private List<T> list;

        public CustomList()
            : this(new List<T>())
        {
        }

        public CustomList(List<T> list)
        {
            this.list = list;
        }

        private int Count => this.list.Count;

        private bool IsEmpty => this.Count == 0;

        public List<T> Elements => this.list;

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public T Remove(int index)
        {
            if (this.IsEmpty)
            {
                throw new ArgumentException("Empty list!");
            }
            if (index < 0 || index > this.Count - 1)
            {
                throw new ArgumentException("Invalid index!");
            }

            var removedElement = this.list[index];
            this.list.RemoveAt(index);
            return removedElement;
        }

        public bool Contains(T element)
        {
            return this.list.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            if (index1 < 0 || index1 > this.Count - 1 ||
                index2 < 0 || index2 > this.Count - 1)
            {
                throw new ArgumentException("Invalid index!");
            }

            T swappedElement = this.list[index1];
            this.list[index1] = this.list[index2];
            this.list[index2] = swappedElement;
        }

        public int CountGreaterThan(T element)
        {
            return this.list.Count(e => e.CompareTo(element) > 0);
        }

        public T Max()
        {
            if (this.IsEmpty)
            {
                throw new ArgumentException("Empty list!");
            }

            return this.list.Max();
        }

        public T Min()
        {
            if (this.IsEmpty)
            {
                throw new ArgumentException("Empty list!");
            }

            return this.list.Min();
        }

        public void Print()
        {
            foreach (var element in this.list)
            {
                Console.WriteLine(element);
            }
        }
    }
}