using E08_MilitaryElite.Interfaces;

namespace E08_MilitaryElite.Models
{
    public class Repair : IRepair
    {
        private string partName;
        private int hoursWorked;

        public Repair(string partName, int hoursWorked)
        {
            this.partName = partName;
            this.hoursWorked = hoursWorked;
        }

        public string PartName => this.partName;

        public int HoursWorked => this.hoursWorked;

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}