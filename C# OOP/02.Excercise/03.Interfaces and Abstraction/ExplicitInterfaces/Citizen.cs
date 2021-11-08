using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        void IPerson.GetName()
        {
            Console.WriteLine(Name);

        }
        void IResident.GetName()
        {
            Console.WriteLine("Mr/Ms/Mrs" + " " + $"{Name}");
        }
    }
}
