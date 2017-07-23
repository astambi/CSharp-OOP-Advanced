using System;

namespace E04_Telephony
{
    public class Startup
    {
        public static void Main()
        {
            var phoneNumbers = ParseInput();
            var webSites = ParseInput();

            var smartphone = new Smartphone();
            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(phoneNumber));
            }
            foreach (var webSite in webSites)
            {
                Console.WriteLine(smartphone.Browse(webSite));
            }
        }

        private static string[] ParseInput()
        {
            return Console.ReadLine()
                .Split(new[] { ' ' }/*, StringSplitOptions.RemoveEmptyEntries*/); // NB!
        }
    }
}