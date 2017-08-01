using System;

namespace E07_EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            var otherPerson = obj as Person;
            return this.Name == otherPerson.Name && this.Age == otherPerson.Age;
        }

        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}