using RecyclingStation.WasteDisposal.Attributes;
using System;

namespace RecyclingStation.BusinessLayer.Attributes
{
    public class RecyclableStrategyAttribute : DisposableAttribute
    {
        public RecyclableStrategyAttribute(Type correspondingStrategyType) 
            : base(correspondingStrategyType)
        {
        }
    }
}
