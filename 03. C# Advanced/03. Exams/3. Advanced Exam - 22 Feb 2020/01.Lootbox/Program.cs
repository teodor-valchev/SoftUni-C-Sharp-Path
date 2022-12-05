using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondBox = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();
            Queue<int> firstBoxQueue = new Queue<int>(firstBox);
            Stack<int> secondBoxStack = new Stack<int>(secondBox);
            int claimedItems = 0;

            while (firstBoxQueue.Any() && secondBoxStack.Any())
            {
                int currentBox = firstBoxQueue.Peek();
                int currentSecondBox = secondBoxStack.Peek();

                if ((currentBox + currentSecondBox) % 2 == 0)
                {
                    firstBoxQueue.Dequeue();
                    secondBoxStack.Pop();
                    claimedItems += currentBox + currentSecondBox;
                }
                else
                {
                    firstBoxQueue.Enqueue(currentSecondBox);
                    secondBoxStack.Pop();
                }
            }
            if (firstBoxQueue.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBoxStack.Count==0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimedItems>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
