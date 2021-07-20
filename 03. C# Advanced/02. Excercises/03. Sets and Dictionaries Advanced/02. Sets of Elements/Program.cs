using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < size[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < size[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            List<int> result = new List<int>();

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    result.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", result));


        }
    }
}
