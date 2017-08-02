using System;

public class Startup
{
    public static void Main()
    {
        CoffeeMachine machine = new CoffeeMachine();

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End") break;

            string[] inputArgs = input.Split();
            if (inputArgs.Length == 1)
            {
                machine.InsertCoin(inputArgs[0]);
            }
            else
            {
                machine.BuyCoffee(inputArgs[0], inputArgs[1]);
            }
        }

        foreach (var coffeeType in machine.CoffeesSold)
        {
            Console.WriteLine(coffeeType);
        }
    }
}