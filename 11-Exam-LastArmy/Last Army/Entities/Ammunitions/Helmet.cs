public class Helmet : Ammunition
{
    private const double WeightConst = 2.3;

    public Helmet(string name)
        : base(name, WeightConst)
    {
    }
}