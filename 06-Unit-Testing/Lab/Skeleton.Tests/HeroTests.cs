using Moq;
using NUnit.Framework;
using System;

[TestFixture]
public class HeroTests
{
    private const int DeadTargetHealth = 0;
    private const int HealthIncrement = 1;
    private const int TargetExperience = 100;
    private const int WeaponAttackPoints = 10;
    private const int WeaponDurability = 10;
    private const string HeroName = "Tested Hero";

    private Hero hero;
    private int heroInitialExperience;

    [SetUp]
    public void TestInit()
    {
        this.heroInitialExperience = 0;
    }

    [Test]
    public void AttackShouldAddTargetExperienceToHeroExperienceWhenTargetIsDead()
    {
        // Arrange     
        var fakeTarget = new FakeDeadTarget(TargetExperience);
        var fakeWeapon = new FakeWeapon(WeaponAttackPoints, WeaponDurability);

        this.hero = new Hero(HeroName, fakeWeapon);

        // Act
        this.hero.Attack(fakeTarget);

        // Assert
        Assert.AreEqual(this.heroInitialExperience + TargetExperience, this.hero.Experience,
            "Hero does not gain target experience!");
    }

    [Test]
    public void AttackShouldNotChangeHeroExperienceWhenTargetIsAlive()
    {
        // Arrange
        var target = new Dummy(DeadTargetHealth + HealthIncrement, TargetExperience);
        var fakeWeapon = new FakeWeapon(WeaponAttackPoints, WeaponDurability);

        this.hero = new Hero(HeroName, fakeWeapon);

        // Act
        this.hero.Attack(target);

        // Assert
        Assert.AreEqual(this.heroInitialExperience, this.hero.Experience,
            "Hero experience should not change!");
    }

    [Test]
    public void AttackShouldAddTargetExperienceToHeroExperienceWhenTargetIsDead_Mock()
    {
        // Arrange
        var fakeTarget = new Mock<ITarget>();
        fakeTarget
            .Setup(t => t.IsDead())
            .Returns(true);
        fakeTarget
            .Setup(t => t.GiveExperience())
            .Returns(TargetExperience);

        var fakeWeapon = new Mock<IWeapon>();

        this.hero = new Hero(HeroName, fakeWeapon.Object);

        // Act
        this.hero.Attack(fakeTarget.Object);

        // Assert
        Assert.AreEqual(this.heroInitialExperience + TargetExperience, this.hero.Experience,
            "Hero does not gain target experience!");
    }

    [Test]
    public void AttackShouldNotChangeHeroExperienceWhenTargetIsAlive_Mock()
    {
        // Arrange
        var fakeTarget = new Mock<ITarget>();
        fakeTarget
            .Setup(t => t.IsDead())
            .Returns(false);
        fakeTarget
            .Setup(t => t.GiveExperience())
            .Callback(() => throw new InvalidOperationException("Dummy is dead."));

        var fakeWeapon = new FakeWeapon(WeaponAttackPoints, WeaponDurability);

        this.hero = new Hero(HeroName, fakeWeapon);

        // Act
        this.hero.Attack(fakeTarget.Object);

        // Assert
        Assert.AreEqual(this.heroInitialExperience, this.hero.Experience,
           "Hero experience should not change!");
    }
}