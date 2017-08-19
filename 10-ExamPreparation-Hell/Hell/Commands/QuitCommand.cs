using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    // Refactored
    //protected QuitCommand()
    //{
    //}

    public QuitCommand(IList<string> args, IManager manager) 
        : base(args, manager)
    {
    }

    // Refactored
    public /*virtual*/ override string Execute()
    {
        return this.Manager.Quit(this.Arguments);
    }
}