namespace E04_WorkForce.Models
{
    public class StandartEmployee : Employee
    {
        private const int HoursPerWeek = 40;

        public StandartEmployee(string name)
            : base(name, HoursPerWeek)
        {
        }
    }
}
