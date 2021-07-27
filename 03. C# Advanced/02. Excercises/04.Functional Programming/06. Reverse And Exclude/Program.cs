using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();
            int devider = int.Parse(Console.ReadLine());
            numbers.Reverse();
            numbers = numbers.Where(num => num % devider !=0).ToList();

            Action<List<int>> print = number => Console.WriteLine(string.Join(" ", number));
            print(numbers);


        }
    }
}
