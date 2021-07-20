using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<int> numbers = new HashSet<int>();
            int found = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
               

                if (numbers.Contains(number))
                {
                    found = number;
                    continue;
                }
                numbers.Add(number);
            }
            Console.WriteLine(found);
        }
    }
}
