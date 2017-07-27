using System;

namespace E10_Tuple
{
    public class Startup
    {
        public static void Main()
        {
            // <string string> <string>
            var inputTokens = Console.ReadLine().Split(' ');
            var tuple1 = new Models.Tuple<string, string>(
                                    $"{inputTokens[0]} {inputTokens[1]}",
                                    inputTokens[2]);
            // string int
            inputTokens = Console.ReadLine().Split(' ');
            var tuple2 = new Models.Tuple<string, int>(
                                    inputTokens[0],
                                    int.Parse(inputTokens[1]));
            // int double
            inputTokens = Console.ReadLine().Split(' ');
            var tuple3 = new Models.Tuple<int, double>(
                                    int.Parse(inputTokens[0]),
                                    double.Parse(inputTokens[1]));
            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}