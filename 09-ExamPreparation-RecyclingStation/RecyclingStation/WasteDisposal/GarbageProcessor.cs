namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        private IStrategyHolder strategyHolder;

        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        // Refactored: Dependency removed
        //public GarbageProcessor()
        //    : this(new StrategyHolder())
        //{
        //}

        public IStrategyHolder StrategyHolder
        {
            get => this.strategyHolder;
            private set => this.strategyHolder = value;
        }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type type = garbage.GetType();

            // Refactored: Get attribute
            DisposableAttribute disposalAttribute = (DisposableAttribute)type
                //.GetCustomAttributes(true)
                //.FirstOrDefault(x => x.GetType() == typeof(DisposableAttribute));
                .GetCustomAttributes(typeof(DisposableAttribute), true)
                .FirstOrDefault();

            // Refactored: Get current strategy
            //IGarbageDisposalStrategy currentStrategy;

            // Refactored: Throw exception only if no attribute, add missing strategies
            if (disposalAttribute == null
                //|| !this.StrategyHolder.GetDisposalStrategies
                //        .TryGetValue(disposalAttribute.GetType(), out currentStrategy)
                )
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            // Refactored: Add strategy if missing
            Type typeOfAttribute = disposalAttribute.GetType();
            if (!this.StrategyHolder.GetDisposalStrategies.ContainsKey(typeOfAttribute))
            {
                Type typeOfCorrespondingStrategy = disposalAttribute.CorrespondingStrategyType;

                IGarbageDisposalStrategy activatedStrategy = (IGarbageDisposalStrategy)Activator
                    .CreateInstance(typeOfCorrespondingStrategy);

                this.StrategyHolder.AddStrategy(typeOfAttribute, activatedStrategy);
            }

            // Refactored: Get current strategy
            IGarbageDisposalStrategy currentStrategy = this.StrategyHolder
                .GetDisposalStrategies[typeOfAttribute];

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}
