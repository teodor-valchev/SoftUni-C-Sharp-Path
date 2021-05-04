using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

           double avarage =  numbers.Average();

         int [] nums   =   numbers.Where(x=>x > avarage).ToArray();

            int count = 0;
            foreach (var number in nums.OrderByDescending(x=>x))
            {
                Console.WriteLine(number);
                count++;
                if (count == 5)
                {
                    break;
                }
            }
            if (avarage>=nums.Length)
            {
                Console.WriteLine("No");
            }
           
        }
    }
}
