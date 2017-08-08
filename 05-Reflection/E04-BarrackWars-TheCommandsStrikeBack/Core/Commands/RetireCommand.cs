namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitToRemove = this.Data[1];
            this.Repository.RemoveUnit(unitToRemove);
            return $"{unitToRemove} retired!";
        }
    }
}
