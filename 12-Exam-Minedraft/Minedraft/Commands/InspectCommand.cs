using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var id = int.Parse(this.Arguments[0]);

        // Get all entities
        var entities = new List<IEntity>();
        GetProviders(entities);
        GetHarvesters(entities);

        // Search in entities
        foreach (var entity in entities)
        {
            if (entity.ID == id)
            {
                var result = new StringBuilder();
                result.AppendLine(string.Format(Constants.EntityFound, entity.GetType().Name));
                result.AppendLine(string.Format(Constants.EntityDurability, entity.Durability));

                return result.ToString().Trim();
            }
        }

        return string.Format(Constants.NoEntityFound, id);
    }

    private void GetHarvesters(List<IEntity> entities)
    {
        var harvesterEntitites = this.HarvesterController
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(t => t.Name == "Entities");

        var harvesters = (IReadOnlyCollection<IEntity>)harvesterEntitites.GetValue(this.HarvesterController);

        entities.AddRange(harvesters);
    }

    private void GetProviders(List<IEntity> entities)
    {
        var providerEntitites = this.ProviderController
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(t => t.Name == "Entities");

        var providers = (IReadOnlyCollection<IEntity>)providerEntitites.GetValue(this.ProviderController);

        entities.AddRange(providers);
    }
}
