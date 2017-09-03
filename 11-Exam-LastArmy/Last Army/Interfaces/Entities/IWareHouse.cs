// Added
public interface IWareHouse
{
    // from MissionController
    void EquipArmy(IArmy army);

    // use exact name to compile unit tests in Judge
    bool TryEquipSoldier(ISoldier soldier);

    // use exact name to compile unit tests in Judge
    void AddAmmunitions(string ammunitionType, int quantity);
}