public class Wizard : AbstractHero
{
    private const int StrengthConst = 25;
    private const int AgilityConst = 25;
    private const int IntelligenceConst = 100;
    private const int HitPointsConst = 100;
    private const int DamageConst = 250;

    public Wizard(string name)
        : base(name, StrengthConst, AgilityConst, IntelligenceConst, HitPointsConst, DamageConst)
    {
    }
}
