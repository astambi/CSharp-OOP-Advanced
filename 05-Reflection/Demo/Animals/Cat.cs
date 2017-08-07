using Demo.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Animals
{
    public class Cat : Animal
    {
        private string somePrivateField;
        private static string somePrivateStaticField;

        //static Cat() // once only
        //{
        //}

        public Cat()
            : this("Pesho")
        {
        }

        public Cat(string name)
        {
            this.Name = name;
        }

        public Cat(string name, int age)
            : this(name)
        {
            this.Age = age;
        }

        [Author("Kenov")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public int Age { get; set; }

        //public void Hello()
        //{
        //    Console.WriteLine($"Hello from cat: {this.Name}");
        //}

        //public void Hello(int version)
        //{
        //    Console.WriteLine($"Hello from cat: {this.Name}.{version}");
        //}

        public static void Hello(int version)
        {
            Console.WriteLine($"Hello from cat: version.{version}");
        }
    }
}