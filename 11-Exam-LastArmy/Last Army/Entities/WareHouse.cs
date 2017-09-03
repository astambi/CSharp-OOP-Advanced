using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory ammunitionFactory;
    private Dictionary<string, int> ammunitions;

    public WareHouse()
        : this(new AmmunitionFactory())
    {
    }

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.ammunitions = new Dictionary<string, int>();
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isFullyEquipped = true;
        var weaponsToUpdate = soldier
                             .Weapons
                             .Where(w => w.Value == null)
                             .Select(w => w.Key)
                             .ToList();
    
        foreach (var weaponName in weaponsToUpdate)
        {
            if (this.ammunitions.ContainsKey(weaponName) &&
                this.ammunitions[weaponName] > 0)
            {
                soldier.Weapons[weaponName] = this.ammunitionFactory.CreateAmmunition(weaponName);
                this.ammunitions[weaponName]--;
            }
            else
            {
                isFullyEquipped = false;
            }
        }

        return isFullyEquipped;
    }

    public void AddAmmunitions(string ammunitionType, int quantity)
    {
        if (!this.ammunitions.ContainsKey(ammunitionType))
        {
            this.ammunitions[ammunitionType] = 0;
        }

        this.ammunitions[ammunitionType] += quantity;
    }
}