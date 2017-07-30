using System.Collections;
using System.Collections.Generic;

namespace Demo
{
    public class BooksCollection : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public BooksCollection()
        {
            this.books = new List<Book>();
        }

        public void Add(Book book)
        {
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            //return this.books.GetEnumerator();        // the inherited books enumerator
            //return new BooksEnumerator(this.books);   // custom enumerator

            for (int i = 0; i < this.books.Count; i += 2)
            {
                yield return this.books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator(); // legacy code
        }

        private class BooksEnumerator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public BooksEnumerator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }

            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current; // legacy code

            public void Dispose() { }

            public bool MoveNext()
            {
                //return ++this.currentIndex < this.books.Count;

                this.currentIndex += 2;
                return this.currentIndex < this.books.Count;

            }

            public void Reset()
            {
                //this.currentIndex = -1;

                this.currentIndex = -2;
            }
        }
    }
}