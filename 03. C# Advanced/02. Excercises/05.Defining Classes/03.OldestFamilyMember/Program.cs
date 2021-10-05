using System;
using System.Collections.Generic;
using System.Linq;

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
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void AddMember(Person person)
        {
            People.Add(person);
        }
        public Person GetOldestPerson()
        {
            Person oldestOne = People.OrderByDescending(x => x.Age)
                  .FirstOrDefault();
            return oldestOne;
        }

    }
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                Person person = new Person(age, name);
                family.AddMember(person);
            }

            Person oldestOne = family.GetOldestPerson();
            Console.WriteLine($"{oldestOne.Name} {oldestOne.Age}");
        }
    }
}


