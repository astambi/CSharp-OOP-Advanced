using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    public AbstractCommand(IList<string> arguments, IManager manager)
    {
        this.Arguments = arguments;
        this.Manager = manager;
    }

    protected IList<string> Arguments { get; private set; }

    protected IManager Manager { get; private set; }

    public abstract string Execute();
}
