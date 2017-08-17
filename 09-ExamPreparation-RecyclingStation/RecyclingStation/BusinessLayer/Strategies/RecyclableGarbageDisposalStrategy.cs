using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLayer.Strategies
{
    public class RecyclableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            var capitalEarned = 400 * garbage.Weight;
            var capitalUsed = 0;

            return capitalEarned - capitalUsed;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            var energyProduced = 0;
            var energyUsed = 0.5 * garbage.CalculateWasteTotalVolume();

            return energyProduced - energyUsed;
        }
    }
}
