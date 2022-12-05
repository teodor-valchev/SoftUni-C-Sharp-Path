using System;
using System.Linq;

namespace _02._Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int numberOfComands = int.Parse(Console.ReadLine());

            var changeArray = input;

            for (int i = 0; i < numberOfComands; i++)
            {
                string command = Console.ReadLine();
                
                

                if (command== "Reverse")
                {
                    Array.Reverse(input);
                }
                else if (command == "Distinct")
                {
                    input = input.Distinct().ToArray();
                  
                }
                

             if (command != "Distinct" && command != "Reverse")
                {
                    string[] replace = command.Split(' ').ToArray();
                    input[int.Parse(replace[1])] = replace[2];

                }

            }
            Console.Write(string.Join(", ",input));

        }
    }
}
