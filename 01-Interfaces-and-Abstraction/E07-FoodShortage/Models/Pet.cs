using System;

namespace E07_FoodShortage.Models
{
    public class Pet : IBirthdate
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.BirthDate = birthdate;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string BirthDate
        {
            get { return this.birthdate; }
            private set { this.birthdate = value; }
        }
    }
}