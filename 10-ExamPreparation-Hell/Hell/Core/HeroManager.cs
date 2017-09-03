using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IManager
{
    private Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IList<string> arguments)
    {
        string result = null;

        // Parse input
        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            // Create Hero
            Type typeOfHero = Type.GetType(heroType);
            var constructors = typeOfHero.GetConstructors();
            var heroParams = new object[] { heroName };

            IHero hero = (IHero)constructors[0].Invoke(heroParams);

            // Add Hero
            this.heroes[hero.Name] = hero;

            // Get Result
            result = string.Format(Constants.HeroCreateMessage,
                                   hero.GetType().Name, hero.Name);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddCommonItem(IList<string> arguments)
    {
        string result = null;

        // Parse input
        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        // Create Item
        var commonItemType = typeof(CommonItem);
        var commonItemParams = new object[] { itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus };

        IItem commonItem = (IItem)Activator.CreateInstance(commonItemType, commonItemParams);

        // Add Item to Hero
        this.heroes[heroName].AddCommonItem(commonItem);

        // Get result
        result = string.Format(Constants.ItemCreateMessage,
                                commonItem.Name, heroName);

        return result;
    }

    public string AddRecipeItem(IList<string> arguments)
    {
        string result = null;

        // Parse input
        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        var requiredItems = arguments.Skip(7).ToList();

        // Create Item
        var recipeType = typeof(RecipeItem);
        var recipeParams = new object[] { itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems };

        IRecipe recipe = (IRecipe)Activator.CreateInstance(recipeType, recipeParams);

        // Add Item to Hero
        this.heroes[heroName].AddRecipe(recipe);

        // Get result
        result = string.Format(Constants.RecipeCreatedMessage,
                                recipe.Name, heroName);

        return result;
    }

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string Quit(IList<string> arguments)
    {
        return QuitSummary();
    }

    private string QuitSummary()
    {
        var builder = new StringBuilder();

        var heroesDescStats = this.heroes.Values
                            .OrderByDescending(h => h.PrimaryStats)
                            .ThenByDescending(h => h.SecondaryStats)
                            .ToList();

        for (int i = 0; i < heroesDescStats.Count; i++)
        {
            // Hero stats
            var hero = heroesDescStats[i];

            builder
                .AppendLine($"{i + 1}. {hero.GetType().Name}: {hero.Name}")
                .AppendLine($"###HitPoints: {hero.HitPoints}")
                .AppendLine($"###Damage: {hero.Damage}")
                .AppendLine($"###Strength: {hero.Strength}")
                .AppendLine($"###Agility: {hero.Agility}")
                .AppendLine($"###Intelligence: {hero.Intelligence}")
                .Append("###Items: ");

            // Items
            var items = hero.Items;

            if (items.Any())
            {
                builder.AppendLine(string.Join(", ", items.Select(x => x.Name)));
            }
            else
            {
                builder.AppendLine("None");
            }
        }

        return builder.ToString().Trim();
    }
}