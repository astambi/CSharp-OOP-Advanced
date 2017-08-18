using System.Collections.Generic;

public interface IHero
{
    string Name { get; }

    long Strength { get; }

    long Agility { get; }

    long Intelligence { get; }

    long HitPoints { get; }

    long Damage { get; }

    // from AbstractHero
    long PrimaryStats { get; }

    // from AbstractHero
    long SecondaryStats { get; }

    // from AbstractHero
    ICollection<IItem> Items { get; }

    // from QuitCommand
    void AddItem(IItem item);

    // from AbstractHero
    void AddRecipe(IRecipe recipe);

    string QuitToString();
}