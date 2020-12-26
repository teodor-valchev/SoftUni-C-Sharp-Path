using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("|").ToList();

            items.Reverse();

            List<string> result = new List<string>();

            foreach (string currentitem in items)
            {
                string[] numbers = currentitem
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (string numbersToAdd in numbers)
                {
                    result.Add(numbersToAdd);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
