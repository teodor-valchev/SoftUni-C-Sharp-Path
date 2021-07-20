using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> chemicals = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < tokens.Length; j++)
                {
                    chemicals.Add(tokens[j]);
                }
               
               
                
            }

            foreach (var chemical in chemicals.OrderBy(c=>c))
            {
                Console.Write(chemical + " ");
            }
        }
    }
}
