using System;
using System.Collections.Generic;

namespace Demo
{
    public class Startup
    {
        public static void Main()
        {
            var books = new BooksCollection();
            books.Add(new Book { Title = "Musk" });
            books.Add(new Book { Title = "Mars" });
            books.Add(new Book { Title = "Tesla" });
            books.Add(new Book { Title = "SpaceX" });
            books.Add(new Book { Title = "Solar" });

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }

            foreach (var number in GetSome())
            {
                Console.WriteLine(number);
            }
        }

        public static IEnumerable<int> GetSome()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return i;
            }
        }
    }
}