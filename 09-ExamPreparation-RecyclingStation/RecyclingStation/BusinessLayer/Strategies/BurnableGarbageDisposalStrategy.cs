using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLayer.Strategies
{
    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            var capitalEarned = 0;
            var capitalUsed = 0;

            return capitalEarned - capitalUsed;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            var garbageTotalVolume = garbage.CalculateWasteTotalVolume();

            var energyProduced = garbageTotalVolume;
            var energyUsed = 0.2 * garbageTotalVolume;

            return energyProduced - energyUsed;
        }
    }
}
