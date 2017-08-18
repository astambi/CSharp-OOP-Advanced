using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    //protected QuitCommand()
    //{
    //}

    public QuitCommand(IList<string> args, IManager manager) 
        : base(args, manager)
    {
    }

    public /*virtual*/ override string Execute()
    {
        return this.Manager.Quit(this.ArgsList);
    }
}