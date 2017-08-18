public abstract class AbstractItem : IItem
{
    public AbstractItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name { get; }

    public int StrengthBonus { get; }

    public int AgilityBonus { get; }

    public int IntelligenceBonus { get; }

    public int HitPointsBonus { get; }

    public int DamageBonus { get; }
}
