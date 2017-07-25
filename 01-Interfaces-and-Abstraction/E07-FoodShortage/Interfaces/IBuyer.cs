namespace E07_FoodShortage.Models
{
    public interface IBuyer
    {
        string Name { get; }
        int Food { get; }

        void BuyFood();
    }
}