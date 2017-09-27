public class PressureProvider : Provider
{
    private const int DurabilityDecrease = 300;
    private const int EnergyOutputMultiplier = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability -= DurabilityDecrease;
        this.EnergyOutput *= EnergyOutputMultiplier;
    }
}
