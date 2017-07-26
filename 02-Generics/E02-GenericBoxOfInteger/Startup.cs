using System;

namespace E02_GenericBoxOfInteger
{
    public class Startup
    {
        public static void Main()
        {
            var numberOfInputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputLines; i++)
            {
                var element = int.Parse(Console.ReadLine());
                var box = new Box<int>(element);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
