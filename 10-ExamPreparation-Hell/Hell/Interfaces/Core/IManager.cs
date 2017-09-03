using System.Collections.Generic;

public interface IManager
{
    string AddHero(IList<string> arguments);

    string AddCommonItem(IList<string> arguments);

    string AddRecipeItem(IList<string> arguments);

    string Inspect(IList<string> arguments);

    string Quit(IList<string> arguments);
}