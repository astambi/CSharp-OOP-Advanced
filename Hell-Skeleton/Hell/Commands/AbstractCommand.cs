using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    public AbstractCommand(IList<string> arguments, IManager manager)
    {
        this.ArgsList = arguments;
        this.Manager = manager;
    }

    public IList<string> ArgsList { get; private set; }

    public IManager Manager { get; private set; }

    public abstract string Execute();
}
