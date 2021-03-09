using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command.ToUpper()!="END")
            {
                string[] cmdArg = command.Split();

                switch (cmdArg[0].ToUpper())
                {
                    case "DELETE":
                        list.RemoveAll(x=>x ==int.Parse(cmdArg[1]));
                        break;
                    case "INSERT":
                        int index =  int.Parse(cmdArg[2]);
                        int element = int.Parse(cmdArg[1]);
                        list.Insert(index,element);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
            Console.Write(string.Join(" ", list));
        }
    }
}
