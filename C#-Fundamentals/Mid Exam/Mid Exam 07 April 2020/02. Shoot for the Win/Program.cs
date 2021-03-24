using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int shotTarggets = 0;

            string comand = Console.ReadLine();

            while (comand != "End")
            {
                int index = int.Parse(comand);

                if (index < 0 || index >= targets.Length || targets[index] == -1)
                {
                    comand = Console.ReadLine();
                    continue;
                }

                int shotTarget = targets[index];
                targets[index] = -1;
                shotTarggets++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] == -1)
                    {
                        continue;
                    }
                    if (targets[i] > shotTarget)
                    {
                        targets[i] -= shotTarget;
                    }
                    else
                    {
                        targets[i] += shotTarget;
                    }
                }

                for (int i = 0; i < targets.Length; i++)
                {
                    int currentTarget = targets[i];


                }


                comand = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shotTarggets} -> {string.Join(" ", targets)}");
        }
    }
}
