using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    private IList<string> args;
    private IManager manager;

    public AbstractCommand(IList<string> args, IManager manager)
    {
        this.args = args;
        this.manager = manager;
    }

    protected IList<string> ArgsList => this.args;

    protected IManager Manager => this.manager;

    public abstract string Execute();
}