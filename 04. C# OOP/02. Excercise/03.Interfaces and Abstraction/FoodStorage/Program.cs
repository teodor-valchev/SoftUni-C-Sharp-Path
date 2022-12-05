using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
   public class Program
    {
      public  static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens.Length==4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthDate = tokens[3];
                    Citizen citizen = new Citizen(name, age, id, birthDate);
                    citizens.Add(citizen);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];
                    Rebel rebel = new Rebel(name, age, group);
                    rebels.Add(rebel);
                }
            }

            string command = Console.ReadLine();

            while (command!="End")
            {
                Citizen citizen = citizens
                    .Where(x => x.Name == command)
                    .FirstOrDefault();

                Rebel rebel = rebels
                    .Where(x => x.Name == command)
                    .FirstOrDefault();

                if (citizen!=null)
                {
                    citizen.BuyFood();
                }
                else if (rebel != null)
                {
                    rebel.BuyFood();
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(rebels.Sum(x=>x.Food) + citizens.Sum(x=>x.Food));
        }
    }
}
