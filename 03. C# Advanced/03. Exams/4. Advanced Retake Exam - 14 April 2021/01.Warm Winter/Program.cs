using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hats = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int[] scarfs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> hatsStack = new Stack<int>(hats);
            Queue<int> scarfsQueue = new Queue<int>(scarfs);

            List<int> set = new List<int>();
            bool newHat = true;
            int curHat = 0;

            while (hatsStack.Any() && scarfsQueue.Any())
            {
                if (newHat == true)
                {
                    int cuurentHat = hatsStack.Peek();
                    curHat = cuurentHat;
                   
                }               
                int cuurentScarf = scarfsQueue.Peek();

                if (curHat > cuurentScarf)
                {
                    int sum = curHat + cuurentScarf;
                    set.Add(sum);
                    hatsStack.Pop();
                    scarfsQueue.Dequeue();
                    newHat = true;
                }
                else if (cuurentScarf > curHat)
                {
                    hatsStack.Pop();
                    newHat = true;
                }
                else
                {
                    scarfsQueue.Dequeue();
                    curHat++;
                    newHat = false;
                }
            }
            Console.WriteLine($"The most expensive set is: {set.Max()}");
            Console.WriteLine(string.Join(" ", set));
        }
    }
}
