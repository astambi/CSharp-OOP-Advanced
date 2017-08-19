using System.Collections.Generic;

public interface IManager
{
    string AddHero(IList<string> arguments);

    string AddItem(IList<string> arguments);

    string AddRecipe(IList<string> arguments);

    string Inspect(IList<string> arguments);

    string Quit(IList<string> arguments);
}
