using RecyclingStation.WasteDisposal.Attributes;
using System;

namespace RecyclingStation.BusinessLayer.Attributes
{
    public class StorableStrategyAttribute : DisposableAttribute
    {
        public StorableStrategyAttribute(Type correspondingStrategyType)
            : base(correspondingStrategyType)
        {
        }
    }
}
