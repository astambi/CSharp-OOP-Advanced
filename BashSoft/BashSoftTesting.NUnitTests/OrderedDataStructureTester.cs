namespace BashSoftTesting.NUnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using BashSoft.Contracts;
    using BashSoft.DataStructures;

    [TestFixture]
    public class OrderedDataStructureTester
    {
        private const int DefaultCapacity = 16;
        private const int DefaultSize = 0;

        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        // Constructor
        [Test]
        public void TestCtorEmpty()
        {
            // Act
            this.names = new SimpleSortedList<string>();

            // Arrange
            Assert.AreEqual(DefaultCapacity, this.names.Capacity); // reversed expected/actual in Lab
            Assert.AreEqual(DefaultSize, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            // Arrange
            var initialCapacity = 20;

            // Act
            this.names = new SimpleSortedList<string>(initialCapacity);

            // Assert
            Assert.AreEqual(initialCapacity, this.names.Capacity);
            Assert.AreEqual(DefaultSize, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            // Arrange
            var initialComparer = StringComparer.OrdinalIgnoreCase;

            // Act
            this.names = new SimpleSortedList<string>(initialComparer);

            // Assert
            Assert.AreEqual(DefaultCapacity, this.names.Capacity);
            Assert.AreEqual(DefaultSize, this.names.Size);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            // Arrange
            var initialCapacity = 30;
            var initialComparer = StringComparer.OrdinalIgnoreCase;

            // Act
            this.names = new SimpleSortedList<string>(initialComparer, initialCapacity);

            // Assert
            Assert.AreEqual(initialCapacity, this.names.Capacity);
            Assert.AreEqual(DefaultSize, this.names.Size);
        }

        // Add
        [Test]
        public void TestAddIncreasesSize()
        {
            // Act
            this.names.Add("Nasko");

            // Assert
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            // Act
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            // Assert
            Assert.AreEqual("Balkan,Georgi,Rosen", string.Join(",", this.names));
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            // Arrange
            var testedSize = 17;

            // Act
            for (int i = 0; i < testedSize; i++)
            {
                this.names.Add("SoftUni");
            }

            // Assert
            Assert.AreEqual(testedSize, this.names.Size);
            Assert.AreNotEqual(DefaultCapacity, this.names.Capacity);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            // Arrange
            var list = new List<string>();
            list.Add("Soft");
            list.Add("Uni");
            var listSize = list.Count;

            // Act
            this.names.AddAll(list);

            // Assert
            Assert.AreEqual(listSize, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            // Arrange
            var list = new List<string>();
            list.Add("Uni");
            list.Add("Soft");
            list.Add("JS");
            list.Add("C#");
            var listSize = list.Count;

            // Act
            this.names.AddAll(list);

            // Assert
            Assert.AreEqual("C#,JS,Soft,Uni", string.Join(",", this.names));
        }

        // Remove
        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            // Arrange
            this.names.Add("SoftUni");

            // Act
            this.names.Remove("SoftUni");

            // Assert
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            // Arrange
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            // Act
            this.names.Remove("Ivan");

            // Assert
            Assert.AreEqual(null,
                            this.names.FirstOrDefault(e => e == "Ivan"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        // JoinWith
        [Test]
        public void TestJoinWithNull()
        {
            // Arrange
            this.names.Add("Soft");
            this.names.Add("Uni");
            this.names.Add("JS");
            this.names.Add("C#");

            // Act
            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            // Arrange
            this.names.Add("Soft");
            this.names.Add("Uni");
            this.names.Add("JS");
            this.names.Add("C#");

            // Assert
            Assert.AreEqual("C#, JS, Soft, Uni", this.names.JoinWith(", "));
        }
    }
}
