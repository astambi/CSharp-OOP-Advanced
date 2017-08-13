namespace _04.Recharge.Refactored
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id) 
            : base(id)
        { }

        public void Sleep()
        {
            // sleep...
        }
    }
}