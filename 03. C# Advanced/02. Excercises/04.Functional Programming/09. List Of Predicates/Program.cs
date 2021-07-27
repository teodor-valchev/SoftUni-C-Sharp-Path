using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            List<int> numberRange = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                numberRange.Add(i);
            }
            List<int> deviders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            foreach (var num in numberRange)
            {
                if (deviders.All(d => num % d == 0))
                {
                    Console.Write(num+" ");
                }
            }
        
           

        }
    }
}
