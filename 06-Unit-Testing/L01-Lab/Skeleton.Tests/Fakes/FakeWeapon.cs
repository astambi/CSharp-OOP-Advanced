public class FakeWeapon : IWeapon
{
    private int attackPoints;
    private int durabilityPoints;

    public FakeWeapon(int attackPoints, int durabilityPoints)
    {
        this.attackPoints = attackPoints;
        this.durabilityPoints = durabilityPoints;
    }

    public int AttackPoints => this.attackPoints;

    public int DurabilityPoints => this.durabilityPoints;

    public void Attack(ITarget target)
    {
        // not implemented
    }
}