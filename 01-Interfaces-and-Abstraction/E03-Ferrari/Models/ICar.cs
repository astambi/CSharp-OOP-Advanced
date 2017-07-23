namespace E03_Ferrari
{
    public interface ICar
    {
        string Model { get; }
        string Driver { get; }

        string UseBrakes();
        string UseGasPedal();
    }
}