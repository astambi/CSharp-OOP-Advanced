using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01HarestingFields
{
    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var classType = typeof(HarvestingFields);
            var classFields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            Dictionary<string, Func<FieldInfo[]>> accessModifierFilters = new Dictionary<string, Func<FieldInfo[]>>
            {
                { "private",  () => classFields.Where(f => f.IsPrivate).ToArray() },
                { "protected",  () => classFields.Where(f => f.IsFamily).ToArray() },
                { "public",  () => classFields.Where(f => f.IsPublic).ToArray() },
                { "all",  () => classFields.ToArray() }
            };

            var builder = new StringBuilder();
            while (true)
            {
                var accessModifier = Console.ReadLine();
                if (accessModifier == "HARVEST") break;

                accessModifierFilters[accessModifier]()
                    .ToList()
                    .ForEach(f => builder.AppendLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}"));
            }
            Console.WriteLine(builder.ToString().Replace("family", "protected").Trim());
        }
    }
}