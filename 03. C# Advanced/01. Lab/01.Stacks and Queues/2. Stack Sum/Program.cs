using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(input);

            string command = Console.ReadLine().ToUpper();

            while (command!="END")
            {
                string[] tokens = command.Split();
                string name = tokens[0].ToUpper();

                if (name =="ADD")
                {
                    int firstNum = int.Parse((tokens[1]));
                    int secondNum = int.Parse((tokens[2]));

                    numbers.Push(firstNum);
                    numbers.Push(secondNum);

                }
                else if (name =="REMOVE")
                {
                    int count = int.Parse((tokens[1]));

                    if (count>=numbers.Count)
                    {
                        command = Console.ReadLine().ToUpper();
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }


                command = Console.ReadLine().ToUpper();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
