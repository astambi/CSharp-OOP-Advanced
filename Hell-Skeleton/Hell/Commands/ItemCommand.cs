using System;
using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(IList<string> arguments, IManager manager) 
        : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddItem(this.ArgsList);
    }

}
