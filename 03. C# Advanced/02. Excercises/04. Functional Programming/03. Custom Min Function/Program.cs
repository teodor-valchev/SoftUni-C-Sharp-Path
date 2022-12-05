using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Func<List<int>, int> minNumber = numbers =>
             {
                 int minimalNumber = int.MaxValue;

                 foreach (var number in numbers)
                 {
                     if (number < minimalNumber)
                     {
                         minimalNumber = number;
                     }
                 }
                 return minimalNumber;
             };

            List<int> numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            int result = minNumber(numbers);
            Console.WriteLine(result);

        }
    }
}
