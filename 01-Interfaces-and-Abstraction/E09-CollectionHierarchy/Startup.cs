using E09_CollectionHierarchy.Interfaces;
using E09_CollectionHierarchy.Models;
using System;
using System.Text;

namespace E09_CollectionHierarchy
{
    public class Startup
    {
        public static void Main()
        {
            var elementsToAdd = Console.ReadLine().Split();
            var numberOfRemoveOperations = int.Parse(Console.ReadLine());

            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myCollection = new MyCollection();

            var builder = new StringBuilder();

            AddElementsToCollection(builder, elementsToAdd, addCollection);
            AddElementsToCollection(builder, elementsToAdd, addRemoveCollection);
            AddElementsToCollection(builder, elementsToAdd, myCollection);

            RemoveElementsFromCollection(builder, numberOfRemoveOperations, addRemoveCollection);
            RemoveElementsFromCollection(builder, numberOfRemoveOperations, myCollection);

            Console.WriteLine(builder.ToString().Trim());
        }

        private static void RemoveElementsFromCollection(StringBuilder builder, int numberOfRemoveOperations, IRemovable collection)
        {
            for (int i = 0; i < numberOfRemoveOperations; i++)
            {
                builder.Append(collection.Remove())
                       .Append(' ');
            }
            builder.AppendLine();
        }

        private static void AddElementsToCollection(StringBuilder builder, string[] elementsToAdd, IAddable collection)
        {
            foreach (var element in elementsToAdd)
            {
                builder.Append(collection.Add(element))
                       .Append(' ');
            }
            builder.AppendLine();
        }
    }
}
