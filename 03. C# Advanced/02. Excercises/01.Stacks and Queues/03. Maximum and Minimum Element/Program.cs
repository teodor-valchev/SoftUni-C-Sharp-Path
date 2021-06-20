using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQuereris = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numberOfQuereris; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int command = numbers[0];

                if (command == 1)
                {
                    int enqueue = numbers[1];

                    queue.Enqueue(enqueue);
                }
                else if (command == 2)
                {
                    if (queue.Count == 0)
                    {
                        continue;
                    }
                    queue.Dequeue();
                }
                else if (command == 3)
                {
                    Console.WriteLine(queue.Max());
                }
                else if (command == 4)
                {
                    Console.WriteLine(queue.Min());
                }
            }

            Console.WriteLine($"{string.Join(", ", queue.Reverse())}");
        }
    }
}
