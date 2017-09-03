public class Assassin : AbstractHero
{
    private const int StrengthConst = 25;
    private const int AgilityConst = 100;
    private const int IntelligenceConst = 15;
    private const int HitPointsConst = 150;
    private const int DamageConst = 300;

    public Assassin(string name)
        : base(name, StrengthConst, AgilityConst, IntelligenceConst, HitPointsConst, DamageConst)
    {
    }
}
