namespace _04.Recharge
{
    using AdapterPattern;

    public class Startup
    {
        public static void Main()
        {
            // Interface Segragation

            ImplementingAdapterPattern();

            ImplementingRefactoringWithMultipleInheritance();
        }

        private static void ImplementingRefactoringWithMultipleInheritance()
        {
            var robot = new Refactored.Robot("Refactored Robot", 100);
            robot.Work(24);
            robot.Recharge();

            var employee = new Refactored.Employee("Refactored employee");
            employee.Work(8);
            employee.Sleep();

            var rechargeStation = new Refactored.RechargeStation();
            rechargeStation.Recharge(robot);

            //rechargeStation.Recharge(empl); // error        
        }

        private static void ImplementingAdapterPattern()
        {
            var robot = new RobotAdapter("Robot Adapter", 100);
            robot.Work(24);
            robot.Recharge();

            var employee = new EmployeeAdapter("Employee Adapter");
            employee.Work(8);
            employee.Sleep();

            var rechargeStation = new AdapterPattern.RechargeStation();
            rechargeStation.Recharge(robot);

            //rechargeStation.Recharge(empl); // error
        }
    }
}
