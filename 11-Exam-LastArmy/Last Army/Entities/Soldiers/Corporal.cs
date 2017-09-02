using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMultiplier = 2.5;
    private const int EnduranceIncreaseConst = 10;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(MachineGun),
        nameof(Helmet),
        nameof(Knife)
    };

    public Corporal(string name, int age, double experience, double endurance)
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
