using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Queue<int[]> petrolPumps = new Queue<int[]>();
            int petrolPumpsCount = int.Parse(Console.ReadLine());


            for (int i = 0; i < petrolPumpsCount; i++)
            {
                int[] petrolPump = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
                petrolPumps.Enqueue(petrolPump);

                
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var petrolPump in petrolPumps)
                {
                    int amountOfPetrol = petrolPump[0];
                    int distanceOfPetrol = petrolPump[1];

                    totalFuel += amountOfPetrol - distanceOfPetrol;

                    if (totalFuel<0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        index++;
                        break;
                    }
                }
                if (totalFuel>=0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
