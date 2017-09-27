public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const double DurabilityModeLoss = 100;

    private int id;
    private double oreOutput;
    private double energyRequirement;
    private double durability;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.id = id;
        this.oreOutput = oreOutput;
        this.energyRequirement = energyRequirement;
        this.durability = InitialDurability;
    }

    public int ID => this.id;

    public double OreOutput
    {
        get => this.oreOutput;
        protected set => this.oreOutput = value;
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set => this.energyRequirement = value;
    }

    public virtual double Durability
    {
        get => this.durability;
        protected set => this.durability = value;
    }

    public void Broke()
    {
        this.durability -= DurabilityModeLoss;
    }

    public double Produce()
    {
        return this.OreOutput;
    }
}