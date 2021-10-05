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

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();


            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                if (age > 30)
                {
                    Person person = new Person(age, name);
                    people.Add(person);
                }
            }

            foreach (var person in people.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}


