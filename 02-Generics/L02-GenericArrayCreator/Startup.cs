using System;

public class Startup
{
    public static void Main()
    {
        string[] strings = ArrayCreator.Create(5, "Pesho");
        int[] integers = ArrayCreator.Create(10, 33);

        //foreach (var element in strings)
        //{
        //    Console.WriteLine(element);
        //}
        //foreach (var element in integers)
        //{
        //    Console.WriteLine(element);
        //}
    }
}