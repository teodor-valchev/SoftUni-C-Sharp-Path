using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int S = int.Parse(commands[1]);
            int X = int.Parse(commands[2]);

            int[] numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();


            Queue<int> nums = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                nums.Enqueue(numbers[i]);


            }

            for (int i = 0; i < S; i++)
            {
                nums.Dequeue();
            }

            if (nums.Contains(X))
            {
                Console.WriteLine("true");
            }
            else if (nums.Count > 0)
            {
                Console.WriteLine(nums.Min());

            }
            else if (nums.Count == 0)
            {
                Console.WriteLine(0);
            }

        }
    }
    }

