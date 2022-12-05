using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().
                 Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            List<int> result = numbers
                .Where(numbers => numbers >= 0)// ще изведе вси1ки числа по големи от нула
                .Reverse()
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("empty");

            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }



        }
    }
}
