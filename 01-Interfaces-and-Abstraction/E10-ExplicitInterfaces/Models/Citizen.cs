using E10_ExplicitInterfaces.Interfaces;

namespace E10_ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        private string name;
        private string country;
        private int age;

        public Citizen(string name, string country, int age)
        {
            this.name = name;
            this.country = country;
            this.age = age;
        }

        public string Name => this.name;

        public string Country => this.country;

        public int Age => this.age;

        string IPerson.GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs " + this.Name;
        }
    }
}
