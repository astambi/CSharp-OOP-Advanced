using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMultiplier = 1.5;
    private const int EnduranceIncreaseConst = 10;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(Helmet)
    };

    public Ranker(string name, int age, double experience, double endurance)
            : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override double OverallSkill => base.OverallSkill * OverallSkillMultiplier;

    public override void Regenerate()
    {
        base.Regenerate();
        this.Endurance += EnduranceIncreaseConst;
    }
}
