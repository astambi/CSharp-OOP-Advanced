public class Easy : Mission
{
    private const string MissionName = "Suppression of civil rebellion";
    private const double EnduranceRequiredConst = 20.0;
    private const double WearLevelDecrementConst = 30.0;

    public Easy(double scoreToComplete)
        : base(MissionName, EnduranceRequiredConst, scoreToComplete)
    {
    }

    public override double WearLevelDecrement => WearLevelDecrementConst;
}