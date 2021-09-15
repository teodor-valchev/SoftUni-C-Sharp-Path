using System;
using System.Collections.Generic;
using System.Linq;

namespace practise
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Queue<string> queue = new Queue<string>();

            while (true)
            {


                if (name == "End")
                {
                    break;
                }
                else if (name == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    name = Console.ReadLine();

                }

                queue.Enqueue(name);
                name = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");


        }
    }
}
