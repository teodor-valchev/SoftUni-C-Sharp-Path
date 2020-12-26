using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();


            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();// tuk e string 

            while (command!= "end")
            {
                string[] cmdArg = command.Split();// a tuk array

                if (cmdArg[0]=="Add")
                {
                    wagons.Add(int.Parse(cmdArg[1]));// za da stane na int
                }
                else
                {
                    int passenger = int.Parse(cmdArg[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currentWwagon = wagons[i];
                        bool isEnoughSpace = currentWwagon + passenger <= maxCapacity;
                        if (isEnoughSpace)
                        {
                            wagons[i] += passenger;
                            break;
                        }
                    }
                    
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",wagons));
        }
    }
}
