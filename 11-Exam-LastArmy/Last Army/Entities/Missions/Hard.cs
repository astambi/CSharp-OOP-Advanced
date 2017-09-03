public class Hard : Mission
{
    private const string MissionName = "Disposal of terrorists";
    private const double EnduranceRequiredConst = 80.0;
    private const double WearLevelDecrementConst = 70.0;

    public Hard(double scoreToComplete)
        : base(MissionName, EnduranceRequiredConst, scoreToComplete)
    {
    }

    public override double WearLevelDecrement => WearLevelDecrementConst;
}
