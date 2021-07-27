using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int start = range[0];
            int end = range[1];
            string command = Console.ReadLine();
            if (command == "odd")
            {
                List<int> nums = OddNumbers(start, end);
                Console.WriteLine(string.Join(" ",nums));
            }
            else if (command == "even")
            {
                List<int> nums = EvenNumbers(start, end);
                Console.WriteLine(string.Join(" ", nums));
            }



            

        }
        static List<int> EvenNumbers(int start, int end)
        {
            List<int> evenNumbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    evenNumbers.Add(i);
                }
            }
            return evenNumbers;
        }
        static List<int> OddNumbers(int start,int end)
        {
            List<int> oddNumbers = new List<int>();

            for (int i = start; i < end; i++)
            {
                if (i%2==1)
                {
                    oddNumbers.Add(i);
                }
            }
            return oddNumbers;
        }
        static List<int> MyWhere(List<int> numbers,Predicate<int>predicate)
        {
            List<int> newList = new List<int>();

            foreach (var currentNum in numbers)
            {
                if (predicate(currentNum))
                {
                    newList.Add(currentNum);
                }
            }
            return newList;
        }
    }
}
