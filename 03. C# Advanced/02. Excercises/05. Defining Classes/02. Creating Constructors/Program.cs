using System;

namespace DefiningClasses
{
    public class Person
    {
        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age)
           : this()
        {
            Age = age;
        }
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
        public string Name { get; set; }
        public int Age { get; set; }

    }
    public class StartUp
    {
      
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Person person = new Person();
            Person person1 = new Person(age);
            Person person2 = new Person(age,name);

        }
    }
}
