using System;
using System.Reflection;

namespace E06_CustomEnumAttribute
{
    public class Startup
    {
        public static void Main()
        {
            var typeInput = Console.ReadLine();
            Type enumType = typeInput == "Suit" ? typeof(CardSuit) : typeof(CardRank);
            var attributes = enumType.GetCustomAttributes();
            Console.WriteLine(string.Join(Environment.NewLine, attributes));
        }
    }
}
