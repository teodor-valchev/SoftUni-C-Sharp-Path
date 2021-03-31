using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resourse = Console.ReadLine();
            Dictionary<string, int> output = new Dictionary<string, int>();
            while (resourse!="stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!output.ContainsKey(resourse))
                {
                    output.Add(resourse, 0);
                }
                output[resourse]+=quantity;
                resourse = Console.ReadLine();
            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
