using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;
    private IComparer<Book> comparer;

    public Library(params Book[] books)
    {
        this.comparer = new BookComparator();
        this.books = new SortedSet<Book>(this.comparer);
        this.books.UnionWith(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly IList<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books) // IEnumerable
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current => this.books[this.currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext() => ++this.currentIndex < this.books.Count;

        public void Reset() => this.currentIndex = -1;
    }
}