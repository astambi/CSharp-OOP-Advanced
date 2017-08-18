namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Collections.Generic;
    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.WasteDisposal.Attributes;

    // make class public (instead of internal) for Unit testing withought Mocking
    public class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder(Dictionary<Type, IGarbageDisposalStrategy> strategies)
        {
            this.strategies = strategies;
        }

        // Refactored Removed Dependency
        //public StrategyHolder()
        //{
        //    this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        //}

        public IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get
            {
                return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies;
            }
        }

        // Refactored
        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            //this.strategies.Add(disposableAttribute, strategy);
            //return true;

            // Refactored
            // Validate Attribute Type
            if (!disposableAttribute.IsSubclassOf(typeof(DisposableAttribute)) ||
                disposableAttribute.IsAbstract)
            {
                return false;
            }
            // Add to collection
            if (!this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Add(disposableAttribute, strategy);
                return true;
            }
            return false;
        }

        // Refactored
        public bool RemoveStrategy(Type disposableAttribute)
        {
            //this.strategies.Remove(disposableAttribute);
            //return true;

            // Refactored
            if (this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Remove(disposableAttribute);
                return true;
            }
            return false;
        }
    }
}
