using Demo.Animals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Demo
{
    public class Startup
    {
        public static void Main()
        {
            //GetTypes<Cat>();
            //GetInterfaces<Cat>();
            //GetBaseTypes<TomCat>();
            //Equality();
            //Activator();
            //Fields();
            //Properties();
            //GenericList();
            //Constructors();
            //Methods();
            Attributes();
        }

        private static void Attributes()
        {
            //var attrName = typeof(Cat)
            //    .GetProperty("Age")
            //    .GetCustomAttribute<AuthorAttribute>()
            //    ?.Name;
            //Console.WriteLine(attrName);

            typeof(Cat)
                .GetProperties()
                .Select(p => new
                {
                    Name = p.Name,
                    Attrs = p.GetCustomAttributes()
                })
                .ToList()
                .ForEach(x =>
                Console.WriteLine($"{x.Name}: " +
                $"{string.Join(", ", x.Attrs.Select(a => a.GetType().Name.Replace("Attribute", string.Empty)))}"));

        }

        private static void Methods()
        {
            //var methods = typeof(Cat).GetMethods();
            var methods = typeof(Cat).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            foreach (var m in methods)
            {
                Console.WriteLine(m.Name);
            }

            var method = typeof(Cat).GetMethod("Hello");
            Console.WriteLine(method.Name);

            var cat = new Cat("Kenov");

            //method.Invoke(cat, new object[0]);
            method.Invoke(cat, new object[] { 1 });
            //method.Invoke(null, new object[] { 1 });

            var parameters = method.GetParameters();
            foreach (var p in parameters)
            {
                Console.WriteLine($"{p.Name} {p.ParameterType}");
            }

            Console.WriteLine(method.ReturnType.Name);

            Console.WriteLine(method.ReturnType.Name == "Void");
            Console.WriteLine(method.ReturnType == typeof(void));
        }

        private static void Constructors()
        {
            //var constructors = typeof(Cat).GetConstructors();
            //foreach (var constructor in constructors)
            //{
            //    Console.WriteLine(constructor.ToString());
            //    var parameters = constructor.GetParameters();
            //    foreach (var p in parameters)
            //    {
            //        Console.WriteLine($"{p.Name} {p.ParameterType}");
            //    }
            //    Console.WriteLine();
            //}

            //var constr = typeof(Cat).GetConstructor(Type.EmptyTypes);
            //var constr = typeof(Cat).GetConstructor(new[] { typeof(string)});
            //var constr = typeof(Cat).GetConstructor(new[] { typeof(int)}); // null
            //var constr = typeof(Cat).GetConstructor(new[] { typeof(string), typeof(int) });

            //Console.WriteLine(constr.ToString());

            //var parameters2 = constr.GetParameters();
            //foreach (var p in parameters2)
            //{
            //    Console.WriteLine($"{p.Name} {p.ParameterType}");
            //}

            //var constr = typeof(Cat).GetConstructor(Type.EmptyTypes);
            //var cat = constr.Invoke(new object[0]);

            var constr = typeof(Cat).GetConstructor(new[] { typeof(string) }); // faster than Activator.GetInstance
            var cat = constr.Invoke(new[] { "Kenov" });
        }

        private static void GenericList()
        {
            var listOfCats = CreateList<Cat>();
            listOfCats.Add(new Cat());
            Console.WriteLine(listOfCats.GetType().Name);
        }

        public static List<T> CreateList<T>()
        {
            var typeOfGenericList = typeof(List<>);
            var typeOfListOfObj = typeOfGenericList.MakeGenericType(typeof(T));
            var listOfObj = (List<T>)System.Activator.CreateInstance(typeOfListOfObj);

            return listOfObj;
        }

        private static void Properties()
        {
            var cat = new Cat
            {
                Name = "Gosho",
                Age = 21
            };

            var typeOfCat = typeof(Cat);
            var properties = typeOfCat.GetProperties();
            foreach (var prop in properties)
            {
                Console.WriteLine(prop.Name);
            }

            var nameProp = typeOfCat.GetProperty("Name");

            Console.WriteLine(nameProp.GetValue(cat)); // slower than cat.Name

            nameProp.SetValue(cat, "Ivan");
            Console.WriteLine(nameProp.GetValue(cat));
        }

        private static void Fields()
        {
            var cat = new Cat();
            var typeOfCat = typeof(Cat);
            var fields = typeOfCat
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic); // default public

            foreach (var field in fields)
            {
                Console.WriteLine(field.Name);
                Console.WriteLine(field.FieldType.Name);

                if (field.Name.Contains("Name"))
                {
                    field.SetValue(cat, "Pesho");
                }
            }
            Console.WriteLine(cat.Name);

            Console.WriteLine(typeOfCat.GetField("somePrivateField", BindingFlags.Instance | BindingFlags.NonPublic));
        }

        private static void Activator()
        {
            var list = new List<Cat>();

            // slower
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                //var cat = (Cat)System.Activator.CreateInstance(typeof(Cat), "Pesho");
                var cat = System.Activator.CreateInstance<Cat>();
                list.Add(cat);
            }
            watch.Stop();
            Console.WriteLine("Activator");
            Console.WriteLine(watch.Elapsed);
            Console.WriteLine(list.Count);

            list = new List<Cat>();
            // faster
            watch = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                //var cat = new Cat("Pesho");
                var cat = new Cat();
                list.Add(cat);
            }
            watch.Stop();
            Console.WriteLine("Ctor");
            Console.WriteLine(watch.Elapsed);
            Console.WriteLine(list.Count);

            list = new List<Cat>();
            watch = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                // faster than ctor => memory
                //var cat = New<Cat>.Instance;

                var cat = New<Cat>.Instance();
                list.Add(cat);
            }
            watch.Stop();
            Console.WriteLine("Expression");
            Console.WriteLine(watch.Elapsed);
            Console.WriteLine(list.Count);
        }

        public class New<T>
            where T : class, new()
        {
            //public static T Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile()(); // the same instance
            public static Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
        }

        private static void Equality()
        {
            var typeOfCat = typeof(Cat);
            var anotherTypeOfCat = typeof(Cat);
            Console.WriteLine(typeOfCat == anotherTypeOfCat);
        }

        private static void GetTypes<T>()
        {
            var startupType = typeof(Startup);
            Console.WriteLine(startupType);

            //var cat = new Cat();
            //var typeOfCat = cat.GetType();

            var type = typeof(T);
            var baseType = type.BaseType;

            Console.WriteLine(type.Name);
            Console.WriteLine(baseType.Name);
            Console.WriteLine(baseType.BaseType.Name);
            //Console.WriteLine(baseType.BaseType.BaseType.Name); // error
        }

        private static void GetInterfaces<T>()
        {
            var type = typeof(T);
            var interfaces = type.GetInterfaces();

            foreach (var interf in interfaces)
            {
                Console.WriteLine(interf.Name);
            }
        }

        private static void GetBaseTypes<T>()
        {
            var type = typeof(T);
            var baseType = type.BaseType;

            while (baseType != typeof(Object))
            {
                Console.WriteLine(baseType.Name);
                baseType = baseType.BaseType;
            }
        }
    }
}