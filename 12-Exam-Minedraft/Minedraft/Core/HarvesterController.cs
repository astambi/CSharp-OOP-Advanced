using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const double FullEnergyRequirement = 100.0;
    private const double HalfEnergyRequirement = 50.0;
    private const double EnergyEnergyRequirement = 20.0;
    private const double MinDurability = 0;

    private IList<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;
    private double oreProduced;
    private string mode;

    public HarvesterController(IHarvesterFactory harvesterFactor, IList<IHarvester> harvesters, IEnergyRepository energyRepository)
    {
        this.factory = harvesterFactor;
        this.harvesters = harvesters;
        this.energyRepository = energyRepository;
        this.oreProduced = 0;
        this.mode = "Full";
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.ToList().AsReadOnly();

    public double OreProduced => this.oreProduced;

    public string ChangeMode(string mode)
    {
        if (mode == "Full" || mode == "Half" | mode == "Energy")
        {
            this.mode = mode;
        }

        // Update harvestsres durability
        foreach (var harvester in this.harvesters)
        {
            harvester.Broke();
        }

        // Remove broken harvesters
        this.harvesters = this.harvesters
            .Where(h => h.Durability >= MinDurability)
            .ToList();

        return string.Format(Constants.ModeChanged, mode);
    }

    public string Produce()
    {
        // Calculate required energy by harvesters
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement * FullEnergyRequirement / 100;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * HalfEnergyRequirement / 100;
            }
            else if (this.mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * EnergyEnergyRequirement / 100;
            }
        }

        // Check if all harvesters can mine
        double minedOres = 0;
        if (this.energyRepository.EnergyStored >= neededEnergy)
        {
            //mine
            this.energyRepository.TakeEnergy(neededEnergy);

            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }

            // Update produced ore by mode 
            if (this.mode == "Energy")
            {
                minedOres *= EnergyEnergyRequirement / 100;
            }
            else if (this.mode == "Half")
            {
                minedOres *= HalfEnergyRequirement / 100;
            }

            this.oreProduced += minedOres;
        }

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);

        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration,
                             harvester.GetType().Name);
    }
}
