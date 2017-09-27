using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var entityTypeToRegister = this.Arguments[0];
        var args = this.Arguments.Skip(1).ToList();

        if (entityTypeToRegister.Equals(nameof(Harvester)))
        {
            return this.HarvesterController.Register(args);
        }
        else if (entityTypeToRegister.Equals(nameof(Provider)))
        {
            return this.ProviderController.Register(args);
        }

        return "Invalid Entity to Register";
    }
}
