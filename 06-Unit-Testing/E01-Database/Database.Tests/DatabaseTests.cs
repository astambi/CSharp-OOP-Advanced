using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int MinDatabaseCapacity = 0;
        private const int MaxDatabaseCapacity = 16;
        private const int Element = 100;

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MaxDatabaseCapacity)]
        public void DatabaseShouldHaveCapacity16(int inputCount)
        {
            // Act
            var database = new Database(new int[inputCount]);

            // Assert
            Assert.AreEqual(MaxDatabaseCapacity, database.Capacity,
                $"Database capacity should be {MaxDatabaseCapacity}!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MaxDatabaseCapacity)]
        public void ConstructorShouldInitializeDBWhenInputElementsCountBetween0And16(int inputCount)
        {
            // Assert
            Assert.DoesNotThrow(
                () => new Database(new int[inputCount]),
                $"Database cannot be initialized with correct number of params!");
        }

        [Test]
        [TestCase(MaxDatabaseCapacity + 1)]
        public void ConstructorShouldNotInitializeDBWhenInputElementsCountExceeds16(int inputCount)
        {
            // Assert
            Assert.Throws<InvalidOperationException>(
                () => new Database(new int[inputCount]),
                $"Input number of elements cannot exceed {MaxDatabaseCapacity}!");
        }

        [Test]
        public void ContructorShouldNotAcceptNullElements()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(
                () => new Database(null),
                "Database cannot be initialized without input!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MinDatabaseCapacity + 1)]
        [TestCase(MaxDatabaseCapacity - 1)]
        [TestCase(MaxDatabaseCapacity)]
        public void ContructorShouldAcceptBetween0And16InputElements(int inputCount)
        {
            //Arrange
            var inputElements = GetElements(inputCount);

            //Assert
            Assert.DoesNotThrow(
                () => new Database(inputElements),
                $"Input number of elements cannot exceed {MaxDatabaseCapacity}!");
        }

        [Test]
        [TestCase(MaxDatabaseCapacity + 1)]
        public void ContructorShouldANotcceptMoreThan16InputElements(int inputCount)
        {
            //Arrange
            var inputElements = GetElements(inputCount);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => new Database(inputElements),
                $"Input number of elements cannot exceed {MaxDatabaseCapacity}!");
        }


        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MaxDatabaseCapacity)]
        public void ContructorShouldAddValidInputElementsCountToDatabase(int inputCount)
        {
            //Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);

            //Assert
            Assert.AreEqual(inputCount, database.Count,
                "Database number of elements do not match input number of elements!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MinDatabaseCapacity + 1)]
        [TestCase(MaxDatabaseCapacity - 1)]
        [TestCase(MaxDatabaseCapacity)]
        public void FetchShouldReturnValidCollectionCount(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);

            // Act
            var databaseElements = database.Fetch();
            var databaseElementsCount = databaseElements.Length;

            // Assert
            Assert.AreEqual(inputCount, databaseElementsCount,
                "Returned database number of elements do not match input number of elements!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MinDatabaseCapacity + 1)]
        [TestCase(MaxDatabaseCapacity - 1)]
        [TestCase(MaxDatabaseCapacity)]
        public void FetchShouldReturnValidCollectionElements(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);

            // Act
            var databaseElements = database.Fetch();
            var databaseElementsCount = databaseElements.Length;

            // Assert
            CollectionAssert.AreEqual(inputElements, databaseElements,
                "Returned database elements do not match input elements!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MaxDatabaseCapacity)]
        public void ContructorShouldAddAllInputElementsToDatabase(int inputCount)
        {
            //Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);
            var databaseElements = database.Fetch();

            //Assert
            CollectionAssert.AreEqual(inputElements, databaseElements,
                "Database elements do not match input elements!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MaxDatabaseCapacity - 1)]
        public void AddSingleElementShouldIncreaseElementsCountsWhenWithinCapacity(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);

            // Act
            database.Add(Element);

            // Assert
            Assert.AreEqual(inputCount + 1, database.Count,
                "Element was not added to database!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MaxDatabaseCapacity - 1)]
        public void AddSeveralElementsShouldIncreaseElementsCountsWhenWithinCapacity(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);
            var elementsToAdd = MaxDatabaseCapacity - inputCount;

            // Act
            for (int i = 0; i < elementsToAdd; i++)
            {
                database.Add(Element * i);
            }

            // Assert
            Assert.AreEqual(inputCount + elementsToAdd, database.Count,
                "Elements were not added to database!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MaxDatabaseCapacity - 1)]
        public void AddSingleElementShouldAddElementToLastIndexWhenWithinCapacity(int inputCount)
        {
            // Arrange
            var database = new Database(new int[inputCount]); // all 0

            // Act
            database.Add(Element); // != 0
            var databaseElements = database.Fetch();
            var lastIndex = databaseElements.Length - 1;

            // Assert
            Assert.AreEqual(Element, databaseElements[lastIndex],
                "Element was not added at the last index in database!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MaxDatabaseCapacity - 1)]
        public void AddSeveralElementsShouldAddEachElementsToLastIndexWhenWihinCapacity(int inputCount)
        {
            // Arrange
            var database = new Database(new int[inputCount]); // all 0
            var elementsToAdd = MaxDatabaseCapacity - inputCount;

            // Act
            for (int i = 0; i < elementsToAdd; i++)
            {
                database.Add(Element * i);
            }
            var databaseElements = database.Fetch();

            // Assert
            for (int i = 0; i < elementsToAdd; i++)
            {
                Assert.AreEqual(Element * i, databaseElements[i + inputCount],
                    "Elements were not added at the last index in database!");
            }
        }

        [Test]
        [TestCase(MaxDatabaseCapacity)]
        public void AddSingleElementShouldNotAddElementWhenAboveCapacity(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => database.Add(Element),
                "Element cannot be added to collection at max capacity!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        [TestCase(MaxDatabaseCapacity)]
        public void AddSeveralElementsShouldNotAddElementWhenAboveCapacity(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);
            var desiredCapacity = MaxDatabaseCapacity + 1;

            // Assert
            for (int i = 0; i < desiredCapacity; i++)
            {
                if (database.Count >= MaxDatabaseCapacity)
                {
                    Assert.Throws<InvalidOperationException>(
                        () => database.Add(Element),
                        "Element cannot be added to collection at max capacity!");
                }
            }
        }

        [Test]
        [TestCase(MinDatabaseCapacity + 1)]
        [TestCase(MaxDatabaseCapacity)]
        public void RemoveSingleShouldDecreaseElementsWhenCollectionIsNotEmpty(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);

            // Act
            database.Remove();

            // Assert
            Assert.AreEqual(inputCount - 1, database.Count,
                "Number of elements did not change!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity + 1)]
        [TestCase(MaxDatabaseCapacity)]
        public void RemoveSeveralShouldDecreaseElementsWhenCollectionIsNotEmpty(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);

            // Act
            while (database.Fetch().Length > 0)
            {
                database.Remove();
            }

            // Assert
            Assert.AreEqual(0, database.Count,
                "Number of elements does not match elements removed!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity)]
        public void RemoveSingleShouldNotDecreaseElementsWhenCollectionIsEmpty(int inputCount)
        {
            // Arrange
            var database = new Database(new int[inputCount]);

            // Assert
            Assert.Throws<InvalidOperationException>(
                () => database.Remove(),
                "Cannot remove an element from an empty dababase!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity + 1)]
        [TestCase(MaxDatabaseCapacity)]
        public void RemoveSeveralShouldNotDecreaseElementsWhenCollectionIsEmpty(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);

            // Assert
            while (true)
            {
                if (database.Count == 0)
                {
                    Assert.Throws<InvalidOperationException>(
                        () => database.Remove(),
                        "Cannot remove an element from an empty dababase!");
                    break;
                }
                else
                {
                    database.Remove();
                }
            }
        }

        [Test]
        [TestCase(MinDatabaseCapacity + 1)]
        [TestCase(MaxDatabaseCapacity)]
        public void RemoveSingleShouldRemoveLastElementWhenCollectionIsNotEmpty(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);

            // Act
            database.Remove();
            inputElements = inputElements.Take(inputCount - 1).ToArray();

            // Assert
            CollectionAssert.AreEqual(inputElements, database.Fetch(),
                "Removed element is not the last!");
        }

        [Test]
        [TestCase(MinDatabaseCapacity + 2)]
        [TestCase(MaxDatabaseCapacity)]
        public void RemoveSeveralShouldRemoveLastElementsWhenCollectionIsNotEmpty(int inputCount)
        {
            // Arrange
            var inputElements = GetElements(inputCount);
            var database = new Database(inputElements);
            var elementsToRemove = inputCount - 3;

            // Act
            for (int i = 0; i < elementsToRemove; i++)
            {
                database.Remove();
            }
            inputElements = inputElements.Take(inputCount - elementsToRemove).ToArray();

            // Assert
            CollectionAssert.AreEqual(inputElements, database.Fetch(),
                "Removed element is not the last!");
        }

        private static int[] GetElements(int inputCount)
        {
            var elements = new List<int>();
            for (int i = 0; i < inputCount; i++)
            {
                elements.Add(i);
            }
            return elements.ToArray();
        }
    }
}