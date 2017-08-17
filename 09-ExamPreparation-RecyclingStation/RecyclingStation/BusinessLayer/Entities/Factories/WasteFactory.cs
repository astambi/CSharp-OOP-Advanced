using RecyclingStation.BusinessLayer.Contracts.Factories;
using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace RecyclingStation.BusinessLayer.Entities.Factories
{
    public class WasteFactory : IWasteFactory
    {
        private const string GarbageSuffix = "Garbage";

        public IWaste Create(string name, double weight, double volumePerKg, string type)
        {
            var fullTypeName = type + GarbageSuffix;

            Type gargabeTypeToActivate = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(fullTypeName, StringComparison.OrdinalIgnoreCase));

            object[] typeParams = new object[] { name, weight, volumePerKg };
            IWaste waste = (IWaste)Activator
                .CreateInstance(gargabeTypeToActivate, typeParams);

            //IWaste waste = (IWaste)Activator
            //    .CreateInstance(gargabeTypeToActivate, name, weight, volumePerKg);

            return waste;
        }
    }
}
