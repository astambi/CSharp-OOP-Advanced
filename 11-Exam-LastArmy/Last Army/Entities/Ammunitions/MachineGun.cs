public class MachineGun : Ammunition
{
    private const double WeightConst = 10.6;

    public MachineGun(string name)
        : base(name, WeightConst)
    {
    }
}
