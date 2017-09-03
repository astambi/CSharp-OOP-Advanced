public abstract class Mission : IMission
{
    private string name;
    private double enduranceRequired;
    private double scoreToComplete;

    public Mission(string name, double enduranceRequired, double scoreToComplete)
    {
        this.name = name;
        this.enduranceRequired = enduranceRequired;
        this.scoreToComplete = scoreToComplete;
    }

    public string Name => this.name;

    public double EnduranceRequired => this.enduranceRequired;

    public double ScoreToComplete => this.scoreToComplete;

    public abstract double WearLevelDecrement { get; } 
}
