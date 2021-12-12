using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEfect = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bombCasing = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            Queue<int> bombsQueueEfect = new Queue<int>(bombEfect);
            Stack<int> bombsCasingEfectStack = new Stack<int>(bombCasing);
            int daturaBomb = 0;
            int cherryBomb = 0;
            int smokeDecoyBomb = 0;
            bool newcasing = false;
            int firstCasing = bombsCasingEfectStack.Peek();





            while (bombsQueueEfect.Any() && bombsCasingEfectStack.Any())
            {
                int firstEfect = bombsQueueEfect.Peek(); 

                 if (newcasing == true)
                {
                    firstCasing = bombsCasingEfectStack.Peek();
                    newcasing = false;
                }

                if (firstEfect + firstCasing == 40)
                {
                    bombsCasingEfectStack.Pop();
                    bombsQueueEfect.Dequeue();
                    daturaBomb++;
                    newcasing = true;

                }
                else if (firstEfect + firstCasing == 60)
                {
                    bombsCasingEfectStack.Pop();
                    bombsQueueEfect.Dequeue();
                    cherryBomb++;
                    newcasing = true;

                }
                else if (firstEfect + firstCasing == 120)
                {
                    bombsCasingEfectStack.Pop();
                    bombsQueueEfect.Dequeue();
                    smokeDecoyBomb++;
                    newcasing = true;

                }
                else
                {
                    firstCasing -= 5;
                    newcasing = false;
                }

                if (daturaBomb >= 3 && cherryBomb >= 3 && smokeDecoyBomb >= 3)
                {
                    break;
                }
            }
            if (daturaBomb >= 3 && cherryBomb >= 3 && smokeDecoyBomb >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombsQueueEfect.Count==0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombsQueueEfect)}");
            }
            if (bombsCasingEfectStack.Count==0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ",bombsCasingEfectStack)}");
            }
            Console.WriteLine($"Cherry Bombs: {cherryBomb}");
            Console.WriteLine($"Datura Bombs: {daturaBomb}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBomb}");
        }
    }
}
