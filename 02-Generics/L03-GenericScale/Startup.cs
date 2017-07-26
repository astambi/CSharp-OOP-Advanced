using System;

public class Startup
{
    public static void Main()
    {
        var scaleIntegers = new Scale<int>(2017, 2);
        Console.WriteLine(scaleIntegers.GetHavier());

        var scaleStrings = new Scale<string>("Soft", "Uni");
        Console.WriteLine(scaleStrings.GetHavier());

        var scaleBools = new Scale<bool>(true, false);
        Console.WriteLine(scaleBools.GetHavier());
    }
}