using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero
{
    private string name;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;
    private IInventory inventory;

    // refactored from protected!
    public AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name => this.name;

    public long Strength => this.strength + this.inventory.TotalStrengthBonus;

    public long Agility => this.agility + this.inventory.TotalAgilityBonus;

    public long Intelligence => this.intelligence + this.inventory.TotalIntelligenceBonus;

    public long HitPoints => this.hitPoints + this.inventory.TotalHitPointsBonus;

    public long Damage => this.damage + this.inventory.TotalDamageBonus;

    public long PrimaryStats => this.Strength + this.Agility + this.Intelligence;

    public long SecondaryStats => this.HitPoints + this.Damage;

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            var inventoryType = typeof(HeroInventory);

            //var fields = inventoryType
            //    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            //    .FirstOrDefault(f => f.Name == "commonItems");

            var inventoryFields = inventoryType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);

            var items = (Dictionary<string, IItem>)inventoryFields
                        .GetValue(this.inventory);

            return items.Values.ToList();
        }
    }

    public void AddCommonItem(IItem commomItem)
    {
        this.inventory.AddCommonItem(commomItem);
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        // Hero Summary
        builder
            .AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}")
            .AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}")
            .AppendLine($"Strength: {this.Strength}")
            .AppendLine($"Agility: {this.Agility}")
            .AppendLine($"Intelligence: {this.Intelligence}")
            .Append("Items:");

        // Items Summary
        var items = this.Items;
        if (items.Count == 0)
        {
            builder.AppendLine(" None");
        }
        else
        {
            builder.AppendLine();

            foreach (var item in items)
            {
                builder
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
}