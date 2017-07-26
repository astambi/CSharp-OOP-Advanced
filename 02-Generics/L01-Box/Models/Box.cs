using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T> : IBox<T>
{
    private IList<T> data;

    public Box()
    {
        this.data = new List<T>();
    }

    public int Count { get { return this.data.Count; } }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove()
    {
        if (this.Count == 0)
        {
            throw new ArgumentException("Empty collection!");
        }
        var removedElement = this.data.LastOrDefault();
        this.data.RemoveAt(this.data.Count - 1);
        return removedElement;
    }
}
