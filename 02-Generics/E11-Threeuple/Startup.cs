using E11_Threeuple.Models;
using System;

namespace E11_Threeuple
{
    public class Startup
    {
        public static void Main()
        {
            // <<first name> <last name>> <address> <town>
            var inputTokens = Console.ReadLine().Split(' ');
            var tuple1 = new Threeuple<string, string, string>(
                                    $"{inputTokens[0]} {inputTokens[1]}",
                                    inputTokens[2],
                                    inputTokens[3]);

            // <name> <liters of beer> <drunk or not>
            inputTokens = Console.ReadLine().Split(' ');
            var tuple2 = new Threeuple<string, int, bool>(
                                    inputTokens[0],
                                    int.Parse(inputTokens[1]),
                                    inputTokens[2] == "drunk" ? true : false);

            // <name> <account balance (double)> <bank name>
            inputTokens = Console.ReadLine().Split(' ');
            var tuple3 = new Threeuple<string, double, string>(
                                    inputTokens[0],
                                    double.Parse(inputTokens[1]),
                                    inputTokens[2]);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}