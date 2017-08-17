using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLayer.Data
{
    public class ProcessingData : IProcessingData
    {
        private double energyBalance;
        private double capitalBalance;

        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double EnergyBalance
        {
            get => this.energyBalance;
            private set => this.energyBalance = value;
        }

        public double CapitalBalance
        {
            get => this.capitalBalance;
            private set => this.capitalBalance = value;
        }
    }
}
