using RecyclingStation.WasteDisposal.Attributes;
using System;

namespace RecyclingStation.BusinessLayer.Attributes
{
    public class BurnableStrategyAttribute : DisposableAttribute
    {
        public BurnableStrategyAttribute(Type correspondingStrategyType) 
            : base(correspondingStrategyType)
        {
        }
    }
}
