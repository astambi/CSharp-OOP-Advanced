using System;
using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var repairValue = double.Parse(this.Arguments[0]);
        var result = this.ProviderController.Repair(repairValue);

        return result;
    }
}
