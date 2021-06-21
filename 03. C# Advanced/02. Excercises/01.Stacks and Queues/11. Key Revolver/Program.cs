using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            int keepSizeOfBarrel = sizeOfBarrel;
            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int value = int.Parse(Console.ReadLine());
            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> lockQueue = new Queue<int>(locks);
            int count = 0;
            int useBullets = 0;


            while (bulletStack.Count > 0 && lockQueue.Count > 0)
            {

                if (bulletStack.Peek() <= lockQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    lockQueue.Dequeue();
                    bulletStack.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletStack.Pop();
                }
                count++;

                if (count == sizeOfBarrel && bulletStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;

                }
                useBullets++;

            }


            if (bulletStack.Count >= 0 && lockQueue.Count == 0)
            {
                int result = value - (useBullets * bulletPrice);
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${result}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
            }
        }
    }
}
