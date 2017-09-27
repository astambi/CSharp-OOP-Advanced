public class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const int DurabilityDailyLoss = 100;

    private int id;
    private double energyOutput;
    private double durability;

    public Provider(int id, double energyOutput)
    {
        this.id = id;
        this.energyOutput = energyOutput;
        this.durability = InitialDurability;
    }

    public int ID => this.id;

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set => this.energyOutput = value;
    }

    public double Durability
    {
        get => this.durability;
        protected set => this.durability = value;
    }

    public void Broke()
    {
        this.durability -= DurabilityDailyLoss;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.durability += val;
    }
}