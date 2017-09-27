using System;

public class InfinityHarvester : Harvester
{
    private const int OreOutputDivider = 10;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

    public override double Durability
    {
        protected set => this.Durability = Math.Max(0, value);
    }
}