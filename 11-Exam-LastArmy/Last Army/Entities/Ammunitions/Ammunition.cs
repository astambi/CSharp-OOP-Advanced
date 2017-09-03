public abstract class Ammunition : IAmmunition
{
    private const int WearLevelMultiplier = 100;

    private string name;
    private double weight;
    private double wearLevel;

    public Ammunition(string name, double weight)
    {
        this.name = name;
        this.weight = weight;
        this.wearLevel = this.weight * WearLevelMultiplier;
    }

    public string Name => this.name;

    public double Weight => this.weight;

    public double WearLevel => this.wearLevel;

    public void DecreaseWearLevel(double wearAmount)
    {
        this.wearLevel -= wearAmount;
    }
}
