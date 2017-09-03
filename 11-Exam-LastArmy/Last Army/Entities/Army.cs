using System.Collections.Generic;
using System.Linq;

public class Army : IArmy
{
    private IList<ISoldier> soldiers;

    public Army()
        : this(new List<ISoldier>())
    {
    }

    public Army(IList<ISoldier> soldiers)
    {
        this.soldiers = soldiers;
    }

    public IReadOnlyList<ISoldier> Soldiers => this.soldiers.ToList().AsReadOnly();

    public void AddSoldier(ISoldier soldier)
    {
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        // Get soldiers to regenerate
        var soldiersToRegenerate = this.soldiers
                                   .Where(s => s.GetType().Name == soldierType);
        // Regenerate
        foreach (var soldier in soldiersToRegenerate)
        {
            soldier.Regenerate();
        }
    }
}