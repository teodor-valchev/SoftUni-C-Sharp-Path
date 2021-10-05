using System;
using DefiningClasses;

namespace DefiningClasses
{


    public class StartUp
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static void Main(string[] args)
        {
            Person personOne = new Person();
            personOne.Name = "Geoge";
            personOne.Age = 23;

            Console.WriteLine($"{personOne.Name} {personOne.Age}");
        }
    }
}

