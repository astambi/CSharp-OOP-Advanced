public class Gun : Ammunition
{
    private const double WeightConst = 1.4;

    public Gun(string name)
        : base(name, WeightConst)
    {
    }
}