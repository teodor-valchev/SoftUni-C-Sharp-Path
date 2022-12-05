using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplicitInterfaces
{
   public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var citizens = new List<IPerson>();
            var residents = new List<IResident>();
     
            while (command!="End")
            {
                string[] tokens = command.Split();
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);
                Citizen citizen = new Citizen(name, age, country);
                citizens.Add(citizen);
                residents.Add(citizen);
                command = Console.ReadLine();
            }

            while (citizens.Count != 0)
            {
                IPerson person = citizens.FirstOrDefault();
                person.GetName();

                IResident resident = residents.FirstOrDefault();
                resident.GetName();

                citizens.Remove(person);
                residents.Remove(resident);
            }  
        }
    }
}
