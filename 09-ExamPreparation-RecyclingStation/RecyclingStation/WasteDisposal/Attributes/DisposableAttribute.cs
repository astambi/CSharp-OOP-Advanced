namespace RecyclingStation.WasteDisposal.Attributes
{
    using System;

    /// <summary>
    /// An attribute class, that represents the base of all Disposable Attribute classes.
    /// </summary>

    [AttributeUsage(AttributeTargets.Class)]
    public class DisposableAttribute : Attribute
    {
        private Type correspondingStrategyType;

        public DisposableAttribute(Type correspondingStrategyType)
        {
            this.CorrespondingStrategyType = correspondingStrategyType;
        }

        public Type CorrespondingStrategyType
        {
            get => this.correspondingStrategyType;
            private set => this.correspondingStrategyType = value;
        }
    }
}
