using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double MaxEndurance = 100;

    private string name;
    private int age;
    private double experience;
    private double endurance;
    private IDictionary<string, IAmmunition> weapons;

    public Soldier(string name, int age, double experience, double endurance)
    {
        this.name = name;
        this.age = age;
        this.experience = experience;
        this.endurance = endurance;
        this.weapons = InitializeWeapons();
    }

    public string Name => this.name;

    public int Age => this.age;

    public double Experience => this.experience;

    public double Endurance
    {
        get { return this.endurance; }

        protected set
        {
            this.endurance = value;

            if (this.endurance > MaxEndurance)
            {
                this.endurance = MaxEndurance;
            }
        }
    }

    public virtual double OverallSkill => this.Age + this.Experience;

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons => this.weapons;

    private IDictionary<string, IAmmunition> InitializeWeapons()
    {
        var initialWeapons = new Dictionary<string, IAmmunition>();

        foreach (var weaponName in this.WeaponsAllowed)
        {
            initialWeapons[weaponName] = null;
        }

        return initialWeapons;
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.weapons.Values
                               .Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values
               .Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public virtual void Regenerate()
    {
        this.Endurance += this.Age;
    }

    public void CompleteMission(IMission mission)
    {
        // Update Soldier
        this.endurance -= mission.EnduranceRequired;
        this.experience += mission.EnduranceRequired;

        // Update Soldier weapons
        AmmunitionRevision(mission.WearLevelDecrement);
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.weapons.Keys.ToList();

        foreach (string weaponName in keys)
        {
            this.weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.weapons[weaponName].WearLevel <= 0)
            {
                this.weapons[weaponName] = null;
            }
        }
    }

    public override string ToString()
    {
        return string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
    }
}