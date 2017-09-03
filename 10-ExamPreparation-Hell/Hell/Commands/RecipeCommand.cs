using System.Collections.Generic;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(IList<string> args, IManager manager)
        : base(args, manager)
    {
    }

    public override string Execute()
    {
        var result = this.Manager.AddRecipeItem(this.ArgsList);
        return result;
    }
}
