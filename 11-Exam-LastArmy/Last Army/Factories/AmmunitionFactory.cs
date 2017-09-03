using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammunitionType = Assembly
                            .GetExecutingAssembly()
                            .GetTypes()
                            .FirstOrDefault(t => t.Name == ammunitionName);

        var ammunitionParams = new object[] { ammunitionName };

        return (IAmmunition)Activator.CreateInstance(ammunitionType, ammunitionParams);
    }
}