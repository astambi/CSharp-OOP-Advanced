using System.Collections.Generic;
using System.Text;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var result = new StringBuilder();
        result.AppendLine(this.ProviderController.Produce());
        result.AppendLine(this.HarvesterController.Produce());

        return result.ToString().Trim();
    }
}
