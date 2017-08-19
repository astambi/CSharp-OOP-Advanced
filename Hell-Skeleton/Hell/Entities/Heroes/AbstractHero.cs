using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class AbstractHero : IHero, IComparable<AbstractHero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    //refactored
    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            Type inventoryType = typeof(HeroInventory);

            var inventoryFields =
                inventoryType
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);

            var items = (Dictionary<string, IItem>)inventoryFields
                        .GetValue(this.inventory);

            return items.Values.ToList(); // Dict to List
        }
    }

    // Added
    public void AddItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        // Hero info
        builder
            .AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}")
            .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
            .AppendLine($"Strength: {this.Strength}")
            .AppendLine($"Agility: {this.Agility}")
            .AppendLine($"Intelligence: {this.Intelligence}");

        // Items info
        var items = this.Items;
        if (!items.Any())
        {
            builder.AppendLine($"Items: None");
        }
        else
        {
            foreach (var item in items)
            {
                builder
                    .AppendLine("Items:")
                    .AppendLine($"###Item: {item.Name}")
                    .AppendLine($"###+{item.StrengthBonus} Strength")
                    .AppendLine($"###+{item.AgilityBonus} Agility")
                    .AppendLine($"###+{item.IntelligenceBonus} Intelligence")
                    .AppendLine($"###+{item.HitPointsBonus} HitPoints")
                    .AppendLine($"###+{item.DamageBonus} Damage");
            }
        }

        return builder.ToString().Trim();
    }

    public string QuitToString()
    {
        var builder = new StringBuilder();

        // Hero info
        builder
            .AppendLine($"{this.GetType().Name}: {this.Name}")
            .AppendLine($"###HitPoints: {this.HitPoints}")
            .AppendLine($"###Damage: {this.Damage}")
            .AppendLine($"###Strength: {this.Strength}")
            .AppendLine($"###Agility: {this.Agility}")
            .AppendLine($"###Intelligence: {this.Intelligence}");

        // Item names
        if (this.Items.Any())
        {
            var itemNames = this.Items.Select(i => i.Name);
            builder.AppendLine("###Items: " + string.Join(", ", itemNames));
        }
        else
        {
            builder.AppendLine("###Items: None");
        }

        return builder.ToString().Trim(); // TODO
    }

}