using System;
using System.Collections.Generic;

namespace Database
{
    public class Startup
    {
        public static void Main()
        {
            var collection = new Database(new int[0]);
            //var collection = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 );
            //collection.Remove();
            //collection.Add(116);
            //collection.Remove();

            var elements = collection.Fetch();
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }
    }
}
