using System;
using System.Linq;

namespace E03_DependencyInversion
{
    public class Startup
    {
        public static void Main()
        {
            var calculator = new PrimitiveCalculator();

            while (true)
            {
                var input = ParseInput(Console.ReadLine());
                if (input[0] == "End") break;

                if (input[0] == "mode")
                {
                    var strategy = input[1][0];
                    calculator.ChangeStrategy(strategy);

                    input = ParseInput(Console.ReadLine());
                }

                var operands = input.Select(int.Parse).ToArray();
                var result = calculator.PerformCalculation(operands[0], operands[1]);
                Console.WriteLine(result);
            }
        }

        private static string[] ParseInput(string input)
        {
            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
