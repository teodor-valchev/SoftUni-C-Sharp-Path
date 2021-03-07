using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().
                 Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            bool isChanged = false;
            StringBuilder output = new StringBuilder();

            while (command[0].ToUpper() != "END")
            {
                switch (command[0].ToUpper())
                {
                    case "ADD":
                        numbers.Add(int.Parse(command[1]));
                        break;
                    case "REMOVE":
                        numbers.Remove(int.Parse(command[1]));
                        break;
                    case "REMOVEAT":
                        numbers.RemoveAt(int.Parse(command[1]));
                        break;
                    case "INSERT":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    case "CONTAINS":
                        if (numbers.Contains(int.Parse(command[1])))
                        {
                            output.AppendLine("Yes");
                        }
                        else
                        {
                            output.AppendLine("No such number");
                        }
                        break;
                    case "PRINTEVEN":
                        output.AppendLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));

                        break;
                    case "PRINTODD":
                        output.AppendLine(string.Join(" ", numbers.Where(n => n % 2 == 1)));

                        break;
                    case "GETSUM":
                        output.AppendLine(numbers.Sum().ToString());

                        break;
                    case "FILTER":
                        string result = string.Empty;

                        switch (command[1])
                        {
                            case "<":
                                result = string.Join(" ", numbers
                                    .Where(n => n < int.Parse(command[2])));
                                break;
                            case ">":
                                result = string.Join(" ", numbers
                                    .Where(n => n > int.Parse(command[2])));
                                break;
                            case ">=":
                                result = string.Join(" ", numbers
                                    .Where(n => n >= int.Parse(command[2])));
                                break;
                            case "<=":
                                result = string.Join(" ", numbers
                                    .Where(n => n <= int.Parse(command[2])));
                                break;
                            default:
                                break;
                        }
                        output.AppendLine(result);
                        break;
                    default:
                        break;
                        
                }
                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(output.ToString());

            if (isChanged)
            {
                Console.WriteLine(string.Join(' ',numbers));
            }

          
        }
    }
}
