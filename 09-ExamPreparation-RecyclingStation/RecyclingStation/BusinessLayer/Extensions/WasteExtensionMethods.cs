// NB! Replace the current namespace with the namespace holding IWaste (piggybacking)

//namespace RecyclingStation.BusinessLayer.Extensions
namespace RecyclingStation.WasteDisposal.Interfaces
{
    public static class WasteExtensionMethods
    {
        public static double CalculateWasteTotalVolume(this IWaste garbage)
        {
            return garbage.Weight * garbage.VolumePerKg;
        }
    }
}
