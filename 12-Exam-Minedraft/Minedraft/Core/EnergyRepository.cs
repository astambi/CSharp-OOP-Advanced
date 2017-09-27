public class EnergyRepository : IEnergyRepository
{
    private double energyStored;

    public double EnergyStored => this.energyStored;

    public void StoreEnergy(double energy)
    {
        this.energyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        if (this.energyStored >= energyNeeded)
        {
            this.energyStored -= energyNeeded;
            return true;
        }

        return false;
    }
}
