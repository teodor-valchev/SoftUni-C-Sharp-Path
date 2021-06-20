using System;
using System.Collections;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            
            int n = int.Parse(Console.ReadLine());
          

            Queue<string> childern = new Queue<string>(input);

          

            while (childern.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    childern.Enqueue(childern.Dequeue());
                    
                }

                Console.WriteLine($"Removed {childern.Dequeue()}");


            }
            Console.WriteLine($"Last is {string.Join(" ",childern)}");

        }
    }
}
