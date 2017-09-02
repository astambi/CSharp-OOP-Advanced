// New
public interface IWareHouse
{
    // use exam name to compile unit tests in Judge
    void AddAmmunitions(string ammunitionName, int ammunitionQuantity);

    // name from MissionController
    void EquipArmy(IArmy army);

    // use exact name to compile unit tests in Judge
    bool TryEquipSoldier(ISoldier soldier);
}