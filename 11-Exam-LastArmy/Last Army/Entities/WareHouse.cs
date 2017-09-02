using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> warehouse;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
        :this(new AmmunitionFactory())
    {
    }

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.warehouse = new Dictionary<string, int>();
    }

    public void AddAmmunitions(string ammunitionName, int ammunitionQuantity)
    {
        if (!this.warehouse.ContainsKey(ammunitionName))
        {
            this.warehouse[ammunitionName] = 0;
        }
        this.warehouse[ammunitionName] += ammunitionQuantity;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isFullyEquipped = true;

        var weaponsNeeded = soldier
                           .Weapons
                           .Where(w => w.Value == null)
                           .Select(w => w.Key)
                           .ToList();

        foreach (var weaponName in weaponsNeeded)
        {
            if (this.warehouse.ContainsKey(weaponName) &&
                this.warehouse[weaponName] > 0)
            {
                soldier.Weapons[weaponName] = this.ammunitionFactory.CreateAmmunition(weaponName);
                this.warehouse[weaponName]--;
            }
            else
            {
                isFullyEquipped = false;
            }
        }

        return isFullyEquipped;
    }
}