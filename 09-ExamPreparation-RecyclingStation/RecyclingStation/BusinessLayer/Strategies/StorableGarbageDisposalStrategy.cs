using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLayer.Strategies
{
    public class StorableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            var capitalEarned = 0;
            var capitalUsed = 0.65 * garbage.CalculateWasteTotalVolume();

            return capitalEarned - capitalUsed;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            var energyProduced = 0;
            var energyUsed = 0.13 * garbage.CalculateWasteTotalVolume();

            return energyProduced - energyUsed;
        }
    }
}
