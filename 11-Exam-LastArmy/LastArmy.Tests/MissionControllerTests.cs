using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

[TestFixture]
public class MissionControllerTests
{
    private const double EasyMissionEnduranceRequired = 20.0;

    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;

    [SetUp]
    public void SetUp()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
    }

    // Constructor
    [Test]
    public void CtorWithAllParamsShouldNotThrowException()
    {
        // Arrange
        var army = new Army();
        var wareHouse = new WareHouse();

        // Assert
        Assert.DoesNotThrow(() => new MissionController(army, wareHouse));
    }

    [Test]
    public void CtorWithNullParamsShouldNotThrowException()
    {
        // Assert
        Assert.DoesNotThrow(() => new MissionController(null, null));
    }

    [Test]
    public void CtorShouldInitializePropertiesCorrectly()
    {
        // Assert
        Assert.AreEqual(0, this.missionController.SuccessMissionCounter);
        Assert.AreEqual(0, this.missionController.FailedMissionCounter);
        Assert.AreEqual(0, this.missionController.Missions.Count);
    }

    // Mission
    [Test]
    public void CtorShouldInitializeMissionsAsQueueOfImmission()
    {
        // Act
        var expectedMissionsType = new Queue<IMission>().GetType();

        // Assert
        Assert.AreEqual(expectedMissionsType, this.missionController.Missions.GetType());
    }

    [Test]
    public void MissionsCountShouldMatchCountOfEnqueuedMissions()
    {
        // Arrange
        this.missionController.Missions.Enqueue(new Easy(10));
        this.missionController.Missions.Enqueue(new Medium(10));
        this.missionController.Missions.Enqueue(new Hard(10));

        // Assert
        Assert.AreEqual(3, this.missionController.Missions.Count);
    }

    // FailMissionsOnHold
    [Test]
    public void FailMissionsOnHoldShouldDeleteAllMissionsInQueue()
    {
        // Arrange
        this.missionController.Missions.Enqueue(new Easy(100));
        this.missionController.Missions.Enqueue(new Medium(100));
        this.missionController.Missions.Enqueue(new Hard(100));

        // Act
        this.missionController.FailMissionsOnHold();

        // Assert
        Assert.AreEqual(0, this.missionController.Missions.Count);
    }

    [Test]
    public void FailMissionsOnHoldShouldIncreaseFailedMissionsCounter()
    {
        // Arrange
        this.missionController.Missions.Enqueue(new Easy(100));
        this.missionController.Missions.Enqueue(new Medium(100));
        this.missionController.Missions.Enqueue(new Hard(100));

        // Act
        this.missionController.FailMissionsOnHold();

        // Assert
        Assert.AreEqual(3, this.missionController.FailedMissionCounter);
    }

    // CollectMissionTeam with Reflextion
    [Test]
    public void CollectMissionTeamShouldAddSoldierToTeamIfReadyForMission()
    {
        /* Ready for mission when all conditions are satisfied:
         * endurance >= MissionEnduranceRequired
         * soldier has all weapons required
         * weapons wear level > 0
         */

        // Arrange
        var mission = new Easy(10);
        AddAllWeaponsToWarehouse();
        InitializeArmyWithEndurance(EasyMissionEnduranceRequired);

        // Act
        var missionTeam = InvokeCollectMissionTeamMethod(mission);

        // Assert
        Assert.AreEqual(3, missionTeam.Count);
    }

    [Test]
    public void CollectMissionTeamShouldNotAddSoldierToTeamWithInsufficientSoldierEndurance()
    {
        // Arrange
        var mission = new Easy(10);
        AddAllWeaponsToWarehouse();
        InitializeArmyWithEndurance(EasyMissionEnduranceRequired - 1);

        // Act
        var missionTeam = InvokeCollectMissionTeamMethod(mission);

        // Assert
        Assert.AreEqual(0, missionTeam.Count);
    }

    [Test]
    public void CollectMissionTeamShouldNotAddSoldierToTeamWithMissingRequiredWeapons()
    {
        // Arrange
        var mission = new Easy(10);
        AddInsuffientWeaponsToWarehouse();
        InitializeArmyWithEndurance(EasyMissionEnduranceRequired);

        // Act
        var missionTeam = InvokeCollectMissionTeamMethod(mission);

        // Assert
        Assert.AreEqual(0, missionTeam.Count);
    }

    // ExecuteMission with Reflextion
    [Test]
    public void ExecuteMissionWithNoTeamShouldBeUnsuccessful()
    {
        // Arrange
        var missionTeam = new List<ISoldier>();
        var mission = new Easy(10);

        // Act
        var result = GetMethod("ExecuteMission")
                    .Invoke(this.missionController, new object[] { mission, missionTeam });

        // Assert
        Assert.AreEqual(false, result);
    }

    [Test]
    public void ExecuteMissionWithUnskilledTeamShouldBeUnsuccessful()
    {
        // Arrange
        var missionTeam = InitializeMissionTeam();
        var teamOverAllSkill = missionTeam.Sum(s => s.OverallSkill);

        var mission = new Easy(teamOverAllSkill + 1);

        // Act
        var result = GetMethod("ExecuteMission")
                    .Invoke(this.missionController, new object[] { mission, missionTeam });

        // Assert
        Assert.AreEqual(false, result);
    }

    [Test]
    public void ExecuteMissionWithSkilledTeamShouldBeSuccessful()
    {
        // Arrange
        var missionTeam = InitializeMissionTeam();
        var teamOverAllSkill = missionTeam.Sum(s => s.OverallSkill);

        var mission = new Easy(teamOverAllSkill);

        // Act
        var result = GetMethod("ExecuteMission")
                    .Invoke(this.missionController, new object[] { mission, missionTeam });

        // Assert
        Assert.AreEqual(true, result);
    }

    [Test]
    public void ExecuteMissionWithSkilledTeamShouldIncreaseSuccessMissionCounter()
    {
        // Arrange
        var missionTeam = InitializeMissionTeam();
        var teamOverAllSkill = missionTeam.Sum(s => s.OverallSkill);

        var mission = new Easy(teamOverAllSkill);

        // Act
        var result = GetMethod("ExecuteMission")
                    .Invoke(this.missionController, new object[] { mission, missionTeam });

        // Assert
        Assert.AreEqual(1, this.missionController.SuccessMissionCounter);
    }

    // PerformMission
    [Test]
    public void PerformMissionWithNoTeamShouldReturnMissionOnHoldMsg()
    {
        // Arrange
        var mission = new Easy(10);

        // Act
        var result = this.missionController.PerformMission(mission).Trim();

        // Assert
        Assert.AreEqual($"Mission on hold - {mission.Name}", result);
    }
    
    [Test]
    public void PerformMissionWithSkilledTeamShouldReturnMissionCompletedMsg()
    {
        // Arrange
        var overallSkill = InitializePerformMission();
        var mission = new Easy(overallSkill);

        // Act
        var result = this.missionController.PerformMission(mission).Trim();

        // Assert
        Assert.AreEqual($"Mission completed - {mission.Name}", result);
    }

    [Test]
    public void PerformMissionWithSkilledTeamShouldIncreaseSuccessMissionCounter()
    {
        // Arrange
        var overallSkill = InitializePerformMission();
        var mission = new Easy(overallSkill);

        // Act
        var result = this.missionController.PerformMission(mission).Trim();

        // Assert
        Assert.AreEqual(1, this.missionController.SuccessMissionCounter);
    }

    [Test]
    public void PerformMissionWithUnskilledTeamShouldReturnMissionOnHoldMsg()
    {
        // Arrange
        var overallSkill = InitializePerformMission();
        var mission = new Easy(overallSkill + 1);

        // Act
        var result = this.missionController.PerformMission(mission).Trim();

        // Assert
        Assert.AreEqual($"Mission on hold - {mission.Name}", result);
    }

    [Test]
    public void PerformMissionWithUnskilledTeamShouldPutMissionInQueue()
    {
        // Arrange
        var overallSkill = InitializePerformMission();
        var mission = new Easy(overallSkill + 1);

        // Act
        var result = this.missionController.PerformMission(mission).Trim();

        var expectedMissions = new Queue<IMission>();
        expectedMissions.Enqueue(mission);

        // Assert
        CollectionAssert.AreEqual(expectedMissions, this.missionController.Missions);
    }

    [Test]
    public void PerformMissionAboveQueueCapacityWithNoTeamShouldCauseMissionsToHoldTheLast3Missions()
    {
        // Arrange
        var mission1 = new Easy(10);
        var mission2 = new Medium(10);
        var mission3 = new Hard(10);
        var mission4 = new Easy(100);

        this.missionController.Missions.Enqueue(mission1);
        this.missionController.Missions.Enqueue(mission2);
        this.missionController.Missions.Enqueue(mission3);

        // Act
        this.missionController.PerformMission(mission4);

        var expectedMissionsInQueue = new Queue<IMission>();
        expectedMissionsInQueue.Enqueue(mission2);
        expectedMissionsInQueue.Enqueue(mission3);
        expectedMissionsInQueue.Enqueue(mission4);

        // Assert
        Assert.AreEqual(3, this.missionController.Missions.Count);
        CollectionAssert.AreEqual(expectedMissionsInQueue, this.missionController.Missions);
    }

    [Test]
    public void PerformMissionAboveQueueCapacityWithUnskilledTeamShouldFailOldestMissionPutAllOthersOnHold()
    {
        // Arrange
        var overallSkill = InitializePerformMission();

        var mission1 = new Hard(overallSkill + 1);
        var mission2 = new Medium(overallSkill + 1);
        var mission3 = new Easy(overallSkill + 1);
        var mission4 = new Easy(overallSkill + 1);

        this.missionController.Missions.Enqueue(mission1);
        this.missionController.Missions.Enqueue(mission2);
        this.missionController.Missions.Enqueue(mission3);

        // Act
        var result = this.missionController.PerformMission(mission4).Trim();

        var expectedResult = new StringBuilder()
                            .AppendLine($"Mission declined - {mission1.Name}")
                            .AppendLine($"Mission on hold - {mission2.Name}")
                            .AppendLine($"Mission on hold - {mission3.Name}")
                            .AppendLine($"Mission on hold - {mission4.Name}")
                            .ToString()
                            .Trim();

        // Assert
        // Correct messages
        Assert.AreEqual(expectedResult, result);

        // Correct failed missions
        Assert.AreEqual(1, this.missionController.FailedMissionCounter);
        Assert.IsFalse(this.missionController.Missions.Contains(mission1));

        // Correct successful missions
        Assert.AreEqual(0, this.missionController.SuccessMissionCounter);
    }

    [Test]
    public void PerformMissionAboveQueueCapacityWithSkilledTeamShouldFailOldestMissionExecuteNext()
    {
        // Arrange
        var overallSkill = InitializePerformMission();

        var mission1 = new Hard(overallSkill);
        var mission2 = new Medium(overallSkill);
        var mission3 = new Easy(overallSkill + 1);
        var mission4 = new Easy(overallSkill + 1);

        this.missionController.Missions.Enqueue(mission1);
        this.missionController.Missions.Enqueue(mission2);
        this.missionController.Missions.Enqueue(mission3);

        // Act
        var result = this.missionController.PerformMission(mission4).Trim();

        var expectedResult = new StringBuilder()
                            .AppendLine($"Mission declined - {mission1.Name}")
                            .AppendLine($"Mission completed - {mission2.Name}")
                            .AppendLine($"Mission on hold - {mission3.Name}")
                            .AppendLine($"Mission on hold - {mission4.Name}")
                            .ToString()
                            .Trim();

        // Assert
        // Correct messages
        Assert.AreEqual(expectedResult, result);

        // Correct failed missions
        Assert.AreEqual(1, this.missionController.FailedMissionCounter);
        Assert.IsFalse(this.missionController.Missions.Contains(mission1));

        // Correct successful missions
        Assert.AreEqual(1, this.missionController.SuccessMissionCounter);
    }

    // Helper methods
    private void AddAllWeaponsToWarehouse()
    {
        this.wareHouse.AddAmmunitions(nameof(AutomaticMachine), 100);
        this.wareHouse.AddAmmunitions(nameof(Gun), 100);
        this.wareHouse.AddAmmunitions(nameof(Helmet), 100);
        this.wareHouse.AddAmmunitions(nameof(Knife), 100);
        this.wareHouse.AddAmmunitions(nameof(MachineGun), 100);
        this.wareHouse.AddAmmunitions(nameof(NightVision), 100);
        this.wareHouse.AddAmmunitions(nameof(RPG), 100);
    }

    private void AddInsuffientWeaponsToWarehouse()
    {
        this.wareHouse.AddAmmunitions(nameof(Gun), 100);
        this.wareHouse.AddAmmunitions(nameof(AutomaticMachine), 100);
    }

    private MethodInfo GetMethod(string methodName)
    {
        return this.missionController
                   .GetType()
                   .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                   .FirstOrDefault(m => m.Name == methodName);
    }

    private List<ISoldier> InvokeCollectMissionTeamMethod(IMission mission)
    {
        return (List<ISoldier>)GetMethod("CollectMissionTeam")
                               .Invoke(this.missionController, new object[] { mission });
    }

    private void InitializeArmyWithEndurance(double endurance)
    {
        var soldier1 = new Ranker(nameof(Ranker), 20, 10, endurance);
        var soldier2 = new Corporal(nameof(Corporal), 20, 10, endurance);
        var soldier3 = new SpecialForce(nameof(SpecialForce), 20, 10, endurance);

        this.wareHouse.TryEquipSoldier(soldier1);
        this.wareHouse.TryEquipSoldier(soldier2);
        this.wareHouse.TryEquipSoldier(soldier3);

        this.army.AddSoldier(soldier1);
        this.army.AddSoldier(soldier2);
        this.army.AddSoldier(soldier3);
    }

    private List<ISoldier> InitializeMissionTeam()
    {
        var soldier1 = new Ranker(nameof(Ranker), 20, 10, EasyMissionEnduranceRequired);
        var soldier2 = new Corporal(nameof(Corporal), 20, 10, EasyMissionEnduranceRequired);
        var soldier3 = new SpecialForce(nameof(SpecialForce), 20, 10, EasyMissionEnduranceRequired);

        AddAllWeaponsToWarehouse();

        this.wareHouse.TryEquipSoldier(soldier1);
        this.wareHouse.TryEquipSoldier(soldier2);
        this.wareHouse.TryEquipSoldier(soldier3);

        return new List<ISoldier> { soldier1, soldier2, soldier3 };
    }

    private double InitializePerformMission()
    {
        AddAllWeaponsToWarehouse();

        var soldier1 = new Ranker(nameof(Ranker), 20, 10, EasyMissionEnduranceRequired);
        var soldier2 = new Corporal(nameof(Corporal), 20, 10, EasyMissionEnduranceRequired);
        var soldier3 = new SpecialForce(nameof(SpecialForce), 20, 10, EasyMissionEnduranceRequired);

        this.army.AddSoldier(soldier1);
        this.army.AddSoldier(soldier2);
        this.army.AddSoldier(soldier3);

        return soldier1.OverallSkill + soldier2.OverallSkill + soldier3.OverallSkill;
    }
}