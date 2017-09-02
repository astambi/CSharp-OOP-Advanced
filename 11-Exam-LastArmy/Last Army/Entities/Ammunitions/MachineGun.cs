public class MachineGun : Ammunition
{
    public const double WeightConst = 10.6;

    public MachineGun(string name)
        : base(name, WeightConst)
    {
    }
}