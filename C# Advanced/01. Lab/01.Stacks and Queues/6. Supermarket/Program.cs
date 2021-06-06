using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Queue<string> names = new Queue<string>();


            while (name != "End")
            {
                names.Enqueue(name);

                if (name == "Paid")
                {
                    for (int i = 0; i <= names.Count; i++)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                    names.Clear();

                }


                name = Console.ReadLine();
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
