public class Helmet : Ammunition
{
    public const double WeightConst = 2.3;

    public Helmet(string name)
        : base(name, WeightConst)
    {
    }
}