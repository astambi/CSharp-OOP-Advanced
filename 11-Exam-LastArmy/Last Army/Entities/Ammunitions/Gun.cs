public class Gun : Ammunition
{
    public const double WeightConst = 1.4;

    public Gun(string name)
        : base(name, WeightConst)
    {
    }
}