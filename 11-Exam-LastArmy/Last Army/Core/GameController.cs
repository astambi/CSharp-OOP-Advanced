using System;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private const string CommandSuffix = "Command";
    private const string RegenerateCommand = "Regenerate";

    private IWriter writer;
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController; //Judge does not accept further abstraction (IMissionController)
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;

    public GameController(IWriter writer, IArmy army, IWareHouse wareHouse, MissionController missionController, ISoldierFactory soldierFactory, IMissionFactory missionFactory)
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

        try
        {
            var method = this.GetType()
                        .GetMethod(commandName, BindingFlags.Instance | BindingFlags.NonPublic);

            var methodParams = new object[] { data };

            method.Invoke(this, methodParams);
        }
        catch (Exception e)
        {
            throw e.InnerException;
        }
    }

    public void RequestFinalSummary()
    {
        // Fail missions on hold
        this.missionController.FailMissionsOnHold();

        // Missions Summary
        this.writer.AppendMessage(OutputMessages.SummaryMissions);

        this.writer.AppendMessage(string.Format(OutputMessages.SuccessfulMissions,
                                                this.missionController.SuccessMissionCounter));

        this.writer.AppendMessage(string.Format(OutputMessages.FailedMissions,
                                                this.missionController.FailedMissionCounter));

        // Soldiers Summary
        var orderedSoldiers = this.army
                              .Soldiers
                              .OrderByDescending(s => s.OverallSkill);

        this.writer.AppendMessage(OutputMessages.SummarySoldiers);

        foreach (var soldier in orderedSoldiers)
        {
            this.writer.AppendMessage(string.Format(OutputMessages.SoldierToString,
                                                    soldier.Name, soldier.OverallSkill));
        }
    }

    private void SoldierCommand(string[] data)
    {
        if (data[0] == RegenerateCommand)
        {
            var soldierType = data[1];
            this.army.RegenerateTeam(soldierType);
        }
        else
        {
            this.AddSoldierToArmy(data);
        }
    }

    private void AddSoldierToArmy(string[] soldierData)
    {
        ISoldier soldier = CreateSoldier(soldierData);

        var isFullyEquipped = this.wareHouse.TryEquipSoldier(soldier);

        if (!isFullyEquipped)
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponForSoldier,
                                                      soldier.GetType().Name,
                                                      soldier.Name));
        }

        this.army.AddSoldier(soldier);
    }

    private ISoldier CreateSoldier(string[] soldierData)
    {
        var type = soldierData[0];
        var name = soldierData[1];
        var age = int.Parse(soldierData[2]);
        var experience = double.Parse(soldierData[3]);
        var endurance = double.Parse(soldierData[4]);

        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        return soldier;
    }

    private void WareHouseCommand(string[] data)
    {
        var ammunitionName = data[0];
        var quantity = int.Parse(data[1]);

        this.wareHouse.AddAmmunitions(ammunitionName, quantity);
    }

    private void MissionCommand(string[] data)
    {
        IMission mission = CreateMission(data);
        var missionResult = this.missionController.PerformMission(mission);

        this.writer.AppendMessage(missionResult);
    }

    private IMission CreateMission(string[] data)
    {
        var difficultyLevel = data[0];
        var scoreToComplete = int.Parse(data[1]);

        IMission mission = this.missionFactory.CreateMission(difficultyLevel, scoreToComplete);

        return mission;
    }
}
