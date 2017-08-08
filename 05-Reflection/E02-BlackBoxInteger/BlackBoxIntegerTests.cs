namespace _02BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    class BlackBoxIntegerTests
    {
        private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;

        static void Main(string[] args)
        {
            var blackboxType = typeof(BlackBoxInt);
            var blackboxInstance = (BlackBoxInt)Activator.CreateInstance(blackboxType, true);
            //var classConstructor = classType
            //    .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, 
            //    Type.DefaultBinder, 
            //    new Type[] { }, 
            //    null);

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var methodTokens = input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                var methodName = methodTokens[0];
                var methodParam = int.Parse(methodTokens[1]);

                blackboxType
                    .GetMethod(methodName, Flags)
                    .Invoke(blackboxInstance, new object[] { methodParam });

                var innerValue = blackboxType
                    .GetFields(Flags)
                    .First()
                    .GetValue(blackboxInstance);

                Console.WriteLine(innerValue);
            }
        }
    }
}