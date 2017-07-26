using System;
using System.Collections.Generic;

namespace E04_GenericSwapMethodIntegers
{
    public class GenericCollection<T>
    {
        private List<T> collection;

        public GenericCollection()
        {
            this.collection = new List<T>();
        }

        public void AddElement(T element)
        {
            this.collection.Add(element);
        }

        public void SwapElements(int index1, int index2)
        {
            T swappedElement = this.collection[index1];
            this.collection[index1] = this.collection[index2];
            this.collection[index2] = swappedElement;
        }

        public void Print()
        {
            foreach (var element in this.collection)
            {
                Console.WriteLine($"{element.GetType().FullName}: {element}");
            }
        }
    }
}
