public class FakeDeadTarget : ITarget
{
    private const bool TargetIsDead = true;
    private const int TargetHealth = 0;

    private int experience;

    public FakeDeadTarget(int experience)
    {
        this.experience = experience;
    }

    public int Health => TargetHealth;

    public bool IsDead() => TargetIsDead;

    public int GiveExperience() => this.experience;

    public void TakeAttack(int attackPoints)
    {
        // not implemented
    }
}