using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private IList<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return this.books.GetEnumerator();
        //return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    //private class LibraryIterator : IEnumerator<Book>
    //{
    //    private readonly IList<Book> books;
    //    private int currentIndex;

    //    public LibraryIterator(IList<Book> books)
    //    {
    //        this.Reset();
    //        this.books = books;
    //    }

    //    public Book Current => throw new NotImplementedException();

    //    object IEnumerator.Current => this.Current;

    //    public void Dispose() { }

    //    public bool MoveNext() => ++this.currentIndex < this.books.Count;

    //    public void Reset() => this.currentIndex = -1;
    //}
}