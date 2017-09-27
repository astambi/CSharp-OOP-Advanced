using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var result = new StringBuilder();
        result.AppendLine(string.Format(Constants.SystemShutdown));

        result.AppendLine(string.Format(Constants.TotalEnergyProduced, this.ProviderController.TotalEnergyProduced));

        result.AppendLine(string.Format(Constants.TotalMinedOre, this.HarvesterController.OreProduced));

        return result.ToString().Trim();
    }
}
