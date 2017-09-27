using System.Collections.Generic;

// Structure 232/250, IO 25/50
// TODO

public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new Reader();
        IWriter writer = new Writer();

        IEnergyRepository energyRepository = new EnergyRepository();

        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IProviderFactory providerFactory = new ProviderFactory();

        IHarvesterController harvesterController = new HarvesterController(harvesterFactory, new List<IHarvester>(), energyRepository);

        IProviderController providerController = new ProviderController(energyRepository);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        IEngine engine = new Engine(reader, writer, commandInterpreter);

        engine.Run();
    }
}