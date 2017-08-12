using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class AxeTest
{
    private const int AxeAttack = 10;
    private const int AxeDurability = 10;
    private const int AxeDurabilityIncrement = 1;
    private const int BrokenAxeDurability = 0;
    private const int DummyHealth = 10;
    private const int DummyExperience = 10;
    private const int DurabilityIncrement = 1;

    private const string ExceptionMessageAxeIsBroken = "Axe is broken.";

    private Axe axe;
    private Dummy dummy;

    [TestInitialize]
    public void TestInit()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [TestMethod]
    public void AttackShouldReduceDurabilityWhenAxeIsNotBroken()
    {
        // Arrange
        var initialDurabilityPoints = this.axe.DurabilityPoints;

        // Act
        this.axe.Attack(this.dummy);
        var resultDurabilityPoints = this.axe.DurabilityPoints;

        // Assert
        Assert.AreEqual(DurabilityIncrement, initialDurabilityPoints - resultDurabilityPoints,
            $"Attack does not change axe durability!");
    }

    [TestMethod]
    public void AttackShouldThrowExceptionWhenAxeIsBroken()
    {
        // Arrange
        this.axe = new Axe(AxeAttack, BrokenAxeDurability + AxeDurabilityIncrement);

        // Act
        this.axe.Attack(this.dummy); // durability = 0

        // Assert
        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => this.axe.Attack(this.dummy),
            "Attack with a broken axe is not allowed!");

        Assert.AreEqual(ExceptionMessageAxeIsBroken, exception.Message, "Invalid exception message!");
    }
}