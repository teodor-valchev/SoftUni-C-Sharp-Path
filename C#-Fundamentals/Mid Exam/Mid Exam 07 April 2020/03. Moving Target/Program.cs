using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commands = tokens[0];
                int index = int.Parse(tokens[1]);
                int value = int.Parse(tokens[2]);

                if (index < 0 || index >= targets.Count)
                {
                    if (commands == "Add")
                    {
                        Console.WriteLine("Invalid placement!");
                        break;
                    }
                    else if (commands == "Strike")
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }

                switch (commands)
                {
                    case "Shoot":

                        targets[index] -= value;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                        break;
                    case "Add":

                        targets.Insert(index, value);
                        break;
                    case "Strike":
                        if (index - value < 0 || index + value >= targets.Count)
                        {
                            Console.WriteLine("Strike missed!");
                            command = Console.ReadLine();
                            continue;
                        }
                        for (int i = index - value; i <= index + value; i++)
                        {
                            targets.RemoveAt(index - value);
                        }
                        break;
                    default:
                        break;
                }



                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}
