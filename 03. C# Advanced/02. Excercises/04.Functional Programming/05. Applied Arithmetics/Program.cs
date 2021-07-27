using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();
            Func<int, int> operation = n => n;
            Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ",numbers));

            string command = Console.ReadLine();

            while (command!="end")
            {
                if (command =="add")
                {
                    operation = n => n + 1;
                    numbers= numbers.Select(operation).ToList();
                }
                else if (command =="multiply")
                {
                    operation = n => n *2;
                    numbers = numbers.Select(operation).ToList();
                }
                else if (command == "subtract")
                {
                    operation = n => n -1;
                    numbers = numbers.Select(operation).ToList();
                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
            
        }
    }
}
