public class Medium : Mission
{
    private const string MissionName = "Capturing dangerous criminals";
    private const double EnduranceRequiredConst = 50.0;
    private const double WearLevelDecrementConst = 50.0;

    public Medium(double scoreToComplete)
        : base(MissionName, EnduranceRequiredConst, scoreToComplete)
    {
    }

    public override double WearLevelDecrement => WearLevelDecrementConst;
}