using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
List<string> groceres = Console.ReadLine()
                 .Split("!", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string command = Console.ReadLine();

            while (command!= "Go Shopping!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string input = tokens[0];
                string item = tokens[1];
              

                switch (input)
                {
                    case "Urgent":
                        if (!groceres.Contains(item))
                        {
                            groceres.Add(item);
                        }
                        break;
                    case "Unnecessary":
                        if (groceres.Contains(item))
                        {
                            groceres.Remove(item);
                        }
                        else
                        {
                            command = Console.ReadLine();
                            continue;
                        }

                        break;
                    case "Correct":
                        string newItem = tokens[2];
                        if (groceres.Contains(item))
                        {

                            int index = groceres.FindIndex(x => x == item);
                            groceres.RemoveAt(index);
                            groceres.Insert(index, newItem);
                            
                        }
                        else
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "Rearrange ":
                        if (groceres.Contains(item))
                        {
                            groceres.Remove(item);
                            groceres.Add(item);

                        }
                        break;
                    default:
                        break;
                }


                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(",",groceres));
        }
    }
}
