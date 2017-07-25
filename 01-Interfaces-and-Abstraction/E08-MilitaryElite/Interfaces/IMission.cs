namespace E08_MilitaryElite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        string State { get; }

        void CompleteMission();
    }
}