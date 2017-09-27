using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

[TestFixture]
public class TestClass
{
    private IProviderController providerController;
    private IEnergyRepository energyRepository;

    [SetUp]
    public void TestInit()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    // TODO

    [Test]
    public void Register()
    {
        // Act 
        var result1 = this.providerController.Register(new List<string> { "Pressure", "10", "100" });
        var result2 = this.providerController.Register(new List<string> { "Standart", "20", "100" });
        var result3 = this.providerController.Register(new List<string> { "Solar", "30", "100" });

        var providers = GetProviders();

        // Assert
        Assert.AreEqual("Successfully registered PressureProvider", result1);
        Assert.AreEqual("Successfully registered StandartProvider", result2);
        Assert.AreEqual("Successfully registered SolarProvider", result3);
        Assert.AreEqual(3, providers.Count);
    }

    [Test]
    public void Produce()
    {
        // Arrange
        this.providerController.Register(new List<string> { "Pressure", "10", "100" });
        this.providerController.Register(new List<string> { "Standart", "20", "100" });
        this.providerController.Register(new List<string> { "Solar", "30", "100" });

        // Act
        var result = this.providerController.Produce();

        // Assert
        Assert.AreEqual("Produced 400 energy today!", result);
        Assert.AreEqual(400, this.providerController.TotalEnergyProduced);
    }

    [Test]
    public void Repair()
    {
        // Arrange
        this.providerController.Register(new List<string> { "Pressure", "10", "100" });
        this.providerController.Register(new List<string> { "Standart", "20", "100" });
        this.providerController.Register(new List<string> { "Solar", "30", "100" });

        // Act
        var result = this.providerController.Repair(100);
        var providers = GetProviders().ToList();

        // Assert
        Assert.AreEqual("Providers are repaired by 100", result);
        Assert.AreEqual(800, providers[0].Durability);
        Assert.AreEqual(1100, providers[1].Durability);
        Assert.AreEqual(1600, providers[2].Durability);
    }

    private IReadOnlyCollection<IEntity> GetProviders()
    {
        var providerEntities = typeof(ProviderController)
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(t => t.Name == "Entities");

        return (IReadOnlyCollection<IEntity>)providerEntities.GetValue(this.providerController);
    }

}

