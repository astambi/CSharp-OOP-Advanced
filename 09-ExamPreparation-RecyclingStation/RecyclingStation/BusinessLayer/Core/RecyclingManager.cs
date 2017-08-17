using RecyclingStation.BusinessLayer.Contracts.Core;
using RecyclingStation.BusinessLayer.Contracts.Factories;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLayer.Core
{
    public class RecyclingManager : IRecyclingStation
    {
        private const string RequirementChangedMessage = "Management requirement changed!";
        private const string ProcessingDeniedMessage = "Processing Denied!";

        private const string ProcessedGarbageMessageToFormat = "{0} kg of {1} successfully processed!";
        private const string StatusMessageToFormat = "Energy: {0} Capital: {1}";
        private const string FloatingPointNumberFormat = "f2";

        private IGarbageProcessor garbageProcessor;
        private IWasteFactory wasteFactory;

        private double capitalBalance;
        private double energyBalance;

        private double minCapitalBalanceRequirement;
        private double minEnergyBalanceRequirement;
        private string garbageTypeRequirement;
        private bool hasRequierementsSet;

        public RecyclingManager(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = wasteFactory;
        }

        // Bonus task
        public string ChangeManagementRequirement(double minEnergyBalance, double minCapitalBalance, string garbageType)
        {
            this.hasRequierementsSet = true;
            this.minCapitalBalanceRequirement = minCapitalBalance;
            this.minEnergyBalanceRequirement = minEnergyBalance;
            this.garbageTypeRequirement = garbageType;

            return RequirementChangedMessage;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            // Bonus task: Check current Management Min Requirements
            if (this.hasRequierementsSet)
            {
                bool meetsRequirements = true;
                if (this.garbageTypeRequirement == type)
                {
                    meetsRequirements = this.energyBalance >= this.minEnergyBalanceRequirement &&
                                        this.capitalBalance >= this.minCapitalBalanceRequirement;
                }

                if (!meetsRequirements)
                {
                    return ProcessingDeniedMessage;
                }
            }

            IWaste waste = this.wasteFactory.Create(name, weight, volumePerKg, type);

            IProcessingData processedData = this.garbageProcessor.ProcessWaste(waste);

            this.capitalBalance += processedData.CapitalBalance;
            this.energyBalance += processedData.EnergyBalance;

            //return $"{waste.Weight:f2} kg of {waste.Name} successfully processed!";

            var formattedMessage = string.Format(
                ProcessedGarbageMessageToFormat,
                waste.Weight.ToString(FloatingPointNumberFormat),
                waste.Name);
            return formattedMessage;
        }

        public string Status()
        {
            //return $"Energy: {this.energyBalance:f2} Capital: {this.capitalBalance:f2}";

            var formattedMessage = string.Format(
                StatusMessageToFormat,
                this.energyBalance.ToString(FloatingPointNumberFormat),
                this.capitalBalance.ToString(FloatingPointNumberFormat));
            return formattedMessage;
        }
    }
}
