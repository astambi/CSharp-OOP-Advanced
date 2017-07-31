using System;
using System.Linq;

namespace E04_Froggy
{
    public class Startup
    {
        public static void Main()
        {
            var stones = Console.ReadLine()
                        .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse);
            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}