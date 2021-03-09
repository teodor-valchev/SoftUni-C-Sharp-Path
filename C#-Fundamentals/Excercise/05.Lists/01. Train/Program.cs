using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
               

            while (command!="end")
            {
                string[] token = command.Split();
                    

                if (token[0]=="Add")
                {
                    wagons.Add(int.Parse(token[1]));
                }
                else
                {
                    int passengers = int.Parse(token[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currentWagon = wagons[i];
                        bool isEnoughSpace = currentWagon + passengers <= maxCapacity;

                        if (isEnoughSpace)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }


                command = Console.ReadLine();
            }

            Console.Write(string.Join(" ",wagons));

        }
    }
}
