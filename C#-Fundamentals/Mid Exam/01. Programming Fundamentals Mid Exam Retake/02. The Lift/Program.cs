using System;
using System.Linq;

namespace _02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());

            int[] wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();



            int peopleLeft = 0;
            bool HasEnoughSpace = true;

            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] > 0)
                {
                    peopleLeft += wagons[i];
                }

                if (people < 4)
                {
                    wagons[i] += people;
                    peopleLeft += people;
                    people -= people;

                    if (people == 0)
                    {
                        HasEnoughSpace = true; 
                        break;
                    }

                }

                wagons[i] += 4;

                if (wagons[i] >= 4)
                {
                    wagons[i] = 4;
                }
                people -= wagons[i];

                if (people > 0)
                {
                    HasEnoughSpace = false;
                }
                else if (people == 0)
                {
                    HasEnoughSpace = true;
                }


            }

            if (HasEnoughSpace)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagons));
            }
            else
            {
                Console.WriteLine($"There isn't enough space! {people + peopleLeft} people in a queue!");
                Console.WriteLine(string.Join(" ", wagons));
            }


        }
    }
}
