using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(IList<string> args, IManager manager)
        : base(args, manager)
    {
    }

    public override string Execute()
    {
        var result = this.Manager.Quit(this.ArgsList);
        return result;
    }
}