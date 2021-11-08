using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
   public class Program
    {
      public  static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var people = new List<Citizen>();
            var pets = new List<Pet>();
            var robots = new List<Robot>();
            while (command!="End")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birhtdate = tokens[4];
                    Citizen citizen = new Citizen(name, age, id, birhtdate);
                    people.Add(citizen);
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birhtdate = tokens[2];
                    Pet pet = new Pet(name, birhtdate);
                    pets.Add(pet);
                }
                else if (tokens[0] == "Robot")
                {
                    string model = tokens[1];
                    string id = tokens[2];
                    Robot robot = new Robot(model, id);
                    robots.Add(robot);
                }
                command = Console.ReadLine();
            }
            string findNumber = Console.ReadLine();
            int count = 0;

            foreach (var person in people.Where(x=>x.Birthdate.EndsWith(findNumber)))
            {
                Console.WriteLine(person.Birthdate);
                count++;
            }
            foreach (var pet in pets.Where(x => x.Birthdate.EndsWith(findNumber)))
            {
                Console.WriteLine(pet.Birthdate);
                count++;
            }
            if (count == 0)
            {
                Console.WriteLine("<empty output>".TrimEnd());
            }           
       }
    }
}
