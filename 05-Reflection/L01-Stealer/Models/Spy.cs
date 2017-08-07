using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        var classType = Type.GetType(className);
        var fieldsInfo = classType
                        .GetFields(BindingFlags.Instance | 
                                   BindingFlags.Static |
                                   BindingFlags.Public | 
                                   BindingFlags.NonPublic)
                        .Where(f => fields.Contains(f.Name));
        var classInstance = Activator.CreateInstance(classType, new object[] { });

        var builder = new StringBuilder();
        builder.AppendLine($"Class under investigation: {classType}");

        foreach (var field in fieldsInfo)
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return builder.ToString().Trim();
    }
}