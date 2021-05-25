using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command!= "Go Shopping!")
            {
                string[] tokens = command.Split();
                string name = tokens[0];
                string item = tokens[1];

                if (name == "Urgent")
                {
                    if (!groceries.Contains(item))
                    {
                        groceries.Insert(0,item);
                    }
                }
                else if (name == "Unnecessary")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }
                }
                else if (name == "Correct")
                {
                    string newItem = tokens[2];

                    if (groceries.Contains(item))
                    {
                      int index = groceries.FindIndex(x=>x ==item);
                        groceries.RemoveAt(index);
                        groceries.Insert(index, newItem);

                    }
                }
                else if (name == "Rearrange")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                        groceries.Add(item);

                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ",groceries));
        }
    }
}
