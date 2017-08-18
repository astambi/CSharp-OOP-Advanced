using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>(); // refactored
    }

    public string AddHero(IList<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });

            // Refactored
            this.heroes.Add(heroName, hero);

            //result = string.Format($"Created {heroType} - {hero.GetType().Name}");
            result = string.Format(Constants.HeroCreateMessage, heroType, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItem(IList<string> arguments/*, IHero hero*/)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);

        // Refactored
        var hero = this.heroes[heroName];
        hero.AddItem(newItem);
        this.heroes[heroName] = hero;

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string AddRecipe(IList<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        IList<string> requiredItems = arguments.Skip(7).ToList();

        IRecipe newRecipe = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);

        var hero = this.heroes[heroName];
        hero.AddRecipe(newRecipe);
        this.heroes[heroName] = hero;

        result = string.Format(Constants.RecipeCreatedMessage, newRecipe.Name, heroName);
        return result;

    }

    public string CreateGame()
    {
        StringBuilder result = new StringBuilder();

        foreach (var hero in this.heroes)
        {
            result.AppendLine(hero.Key);
        }

        return result.ToString();
    }

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string Quit(IList<string> argsList)
    {
        var orderedHeros = this.heroes
                               .Values
                               .OrderByDescending(h => h.PrimaryStats)
                               .ThenByDescending(h => h.SecondaryStats)
                               .ToList();
        var builder = new StringBuilder();

        for (int i = 0; i < orderedHeros.Count; i++)
        {
            builder.Append($"{i + 1}. ")
                   .AppendLine(orderedHeros[i].QuitToString());
        }

        return builder.ToString().Trim();
    }

    //Само Батман знае как работи това
    //public static void GenerateResult()
    //{
    //    const string PropName = "_connectionString";

    //    var type = typeof(HeroCommand);

    //    FieldInfo fieldInfo = null;
    //    PropertyInfo propertyInfo = null;
    //    while (fieldInfo == null && propertyInfo == null && type != null)
    //    {
    //        fieldInfo = type.GetField(PropName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        if (fieldInfo == null)
    //        {
    //            propertyInfo = type.GetProperty(PropName,
    //                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    //        }

    //        type = type.BaseType;
    //    }
    //}

    //public static void DontTouchThisMethod()
    //{
    //    //това не трябва да го пипаме, че ако го махнем ще ни счупи цялата логика
    //    var l = new List<string>();
    //    var m = new Manager();
    //    HeroCommand cmd = new HeroCommand(l, m);
    //    var str = "Execute";
    //    Console.WriteLine(str);
    //}
}