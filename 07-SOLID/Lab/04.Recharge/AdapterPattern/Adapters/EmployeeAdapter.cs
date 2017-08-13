namespace _04.Recharge.AdapterPattern
{
    public class EmployeeAdapter : ISleeper
    {
        private Employee employee;

        public EmployeeAdapter(string id)
        {
            this.employee = new Employee(id);
        }

        public void Sleep()
        {
            this.employee.Sleep();
        }

        public void Work(int hours)
        {
            this.employee.Work(hours);
        }
    }
}
