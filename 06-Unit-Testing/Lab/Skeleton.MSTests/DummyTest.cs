using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Skeleton.Test
{
    [TestClass]
    public class DummyTests
    {
        private const int AttackPoints = 1;
        private const int DeadDummyHealth = 0;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private const string ExceptionMessageDummyIsDead = "Dummy is dead.";
        private const string ExceptionMessageDummyIsNotDead = "Target is not dead.";

        private Dummy dummy;

        [TestInitialize]
        public void TestInit()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [TestMethod]
        public void TakeAttackShouldReduceDummyHealthWhenDummyIsNotDead()
        {
            // Arrange
            var initialDummmyHealth = this.dummy.Health;

            // Act
            this.dummy.TakeAttack(AttackPoints);
            var resultDummyHealth = this.dummy.Health;

            // Assert
            Assert.AreEqual(AttackPoints, initialDummmyHealth - resultDummyHealth,
                $"Attack does not reduce dummy health by {AttackPoints}!");
        }

        [TestMethod]
        public void TakeAttackShouldThrowExceptionWhenDummyIsDead()
        {
            // Arrange
            this.dummy = new Dummy(DeadDummyHealth + 1, DummyExperience);

            // Act
            this.dummy.TakeAttack(AttackPoints); // => dead dummy

            // Assert
            var exception = Assert.ThrowsException<InvalidOperationException>(
                () => this.dummy.TakeAttack(AttackPoints),
                "Attacking a dead dummy is not allowed!");

            Assert.AreEqual(ExceptionMessageDummyIsDead, exception.Message, "Invalid exception message!");
        }

        [TestMethod]
        public void GiveExperienceShouldReturnExperienceWhenDummyIsDead()
        {
            // Arrange
            this.dummy = new Dummy(DeadDummyHealth, DummyExperience);

            // Act
            var returnedDummyExperience = this.dummy.GiveExperience();

            // Assert
            Assert.AreEqual(DummyExperience, returnedDummyExperience,
                $"Dead dummy does not give experience!");
        }

        [TestMethod]
        public void GiveExperienceShouldThrowExceptionWhenDummyIsNotDead()
        {
            // Assert
            var exception = Assert.ThrowsException<InvalidOperationException>(
                () => this.dummy.GiveExperience(),
                "Alive dummy should not give experience!");

            Assert.AreEqual(ExceptionMessageDummyIsNotDead, exception.Message, "Invalid exception message!");
        }
    }
}
