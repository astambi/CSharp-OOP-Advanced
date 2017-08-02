using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private List<CoffeeType> coffeesSold;
    private int coins;

    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold => this.coffeesSold;

    public void BuyCoffee(string size, string type)
    {
        bool isValidCoffeeType = Enum.TryParse(type, true, out CoffeeType coffeeType);
        bool isValidCoffeeSize = Enum.TryParse(size, true, out CoffeePrice coffeeSize);
        int coffeePrice = (int)coffeeSize;

        if (isValidCoffeeType &&
            isValidCoffeeSize &&
            this.coins >= coffeePrice)
        {
            this.coffeesSold.Add(coffeeType);
            this.coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        var cointValue = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int)cointValue;
    }
}