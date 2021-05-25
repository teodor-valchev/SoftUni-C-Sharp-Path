using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] tokens = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string commands = tokens[0];
                string item = tokens[1];

                if (commands == "Collect")
                {
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }

               else if (commands == "Drop")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (commands == "Combine Items")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }




                command = Console.ReadLine();
            }
        }
    }
}
