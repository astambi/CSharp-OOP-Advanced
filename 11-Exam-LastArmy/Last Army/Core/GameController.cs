using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private const string CommandSuffix = "Command";
    private const string RegenerateCommand = "Regenerate";

    private IWriter writer;
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;

    public GameController(IWriter writer, IArmy army, IWareHouse wareHouse,
                          MissionController missionController,
                          ISoldierFactory soldierFactory, IMissionFactory missionFactory)
    {
        this.writer = writer;
        this.army = army;
        this.wareHouse = wareHouse;
        this.missionController = missionController;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
    }

    public void ProcessInput(string input)
    {
        var data = input.Split();

        var commandName = data[0] + CommandSuffix;
        data = data.Skip(1).ToArray();

        // Invoke Command Method
        var commandMethod = this.GetType()
                            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                            .FirstOrDefault(m => m.Name == commandName);

        var methodParams = new object[] { data };

        commandMethod.Invoke(this, methodParams);
    }

    private void SoldierCommand(string[] data)
    {
        if (data[0] == RegenerateCommand)
        {
            RegenerateSoldierCommand(data);
        }
        else
        {
            AddSoldierToArmyCommand(data);
        }
    }

    private void RegenerateSoldierCommand(string[] data)
    {
        var soldierType = data[1];
        this.army.RegenerateTeam(soldierType);
    }

    private void AddSoldierToArmyCommand(string[] data)
    {
        // Create Soldier
        ISoldier soldier = CreateSoldier(data);

        // Equip soldier 
        bool isFullyEquipped = this.wareHouse.TryEquipSoldier(soldier);

        // Add soldier to army if fully equipped
        if (!isFullyEquipped)
        {
            this.writer.AppendMessage(string.Format(OutputMessages.NoWeaponForSoldier,
                                      soldier.GetType().Name, soldier.Name));
        }
        else
        {
            this.army.AddSoldier(soldier);
        }
    }

    private ISoldier CreateSoldier(string[] data)
    {
        // Parse input
        var type = data[0];
        var name = data[1];
        var age = int.Parse(data[2]);
        var experience = double.Parse(data[3]);
        var endurance = double.Parse(data[4]);

        // Create Soldier
        return this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);
    }

    private void WareHouseCommand(string[] data)
    {
        // Parse input
        var ammunitionName = data[0];
        var ammunitionQuantity = int.Parse(data[1]);

        // Add Ammunitions to Warehouse
        this.wareHouse.AddAmmunitions(ammunitionName, ammunitionQuantity);
    }

    private void MissionCommand(string[] data)
    {
        // Create mission
        IMission mission = CreateMission(data);

        // Perform Mission
        var missionResult = this.missionController.PerformMission(mission);
        this.writer.AppendMessage(missionResult);
    }

    private IMission CreateMission(string[] data)
    {
        // Parse input
        var missionType = data[0];
        var missionScoreToComplete = double.Parse(data[1]);

        // Create Mission
        return this.missionFactory.CreateMission(missionType, missionScoreToComplete);
    }

    public void RequestGameResult()
    {
        // Fail missions on hold
        this.missionController.FailMissionsOnHold();

        // Append Summaries
        AppendMissionsSummary();
        AppendSoldiersSummary();
    }

    private void AppendMissionsSummary()
    {
        this.writer.AppendMessage(OutputMessages.SummaryMisionResults);
        this.writer.AppendMessage(string.Format(OutputMessages.SuccessfulMissions,
                                  this.missionController.SuccessMissionCounter));
        this.writer.AppendMessage(string.Format(OutputMessages.FailedMissions,
                                  this.missionController.FailedMissionCounter));
    }

    private void AppendSoldiersSummary()
    {
        var soldiersInDescOrder = this.army.Soldiers
                                .OrderByDescending(s => s.OverallSkill);

        this.writer.AppendMessage(OutputMessages.SummarySoldiers);
        foreach (var soldier in soldiersInDescOrder)
        {
            this.writer.AppendMessage(soldier.ToString());
        }
    }
}
