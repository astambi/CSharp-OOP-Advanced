public class Barbarian : AbstractHero
{
    private const int StrengthConst = 90;
    private const int AgilityConst = 25;
    private const int IntelligenceConst = 10;
    private const int HitPointsConst = 350;
    private const int DamageConst = 150;

    public Barbarian(string name)
        : base(name, StrengthConst, AgilityConst, IntelligenceConst, HitPointsConst, DamageConst)
    {
    }
}