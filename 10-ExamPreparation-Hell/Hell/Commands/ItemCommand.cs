using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(IList<string> args, IManager manager)
        : base(args, manager)
    {
    }

    public override string Execute()
    {
        var result = this.Manager.AddCommonItem(this.ArgsList);
        return result;
    }
}
