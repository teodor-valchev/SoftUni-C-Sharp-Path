using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command!="Party!")
            {
                string[] tokens = command
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string choose = tokens[0];
                string startOrEnd = tokens[1];


                if (choose =="Remove")
                {
                    if (startOrEnd.ToUpper()== "STARTSWITH")
                    {
                        string character = tokens[2];
                        
                    }
                }



                command = Console.ReadLine();
            }
        }
    }
}
