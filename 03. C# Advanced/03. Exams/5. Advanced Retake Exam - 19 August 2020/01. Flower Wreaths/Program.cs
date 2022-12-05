using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int[] roses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> liliesStack = new Stack<int>(lilies);
            Queue<int> rosesQueue = new Queue<int>(roses);
            int whreats = 0;
            int currRose = 0;
            int currenLily = 0;
            int restSum = 0;
            bool newPlants = true;

            while (liliesStack.Any() && rosesQueue.Any())
            {
                if (newPlants == true)
                {
                    int NewLily = liliesStack.Peek();
                    int NewRose = rosesQueue.Peek();
                    currRose = NewRose;
                    currenLily = NewLily;                   
                }
                if (currenLily + currRose == 15)
                {
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                    whreats++;
                    newPlants = true;
                }
                else if (currenLily+currRose>15)
                {
                    currenLily -= 2;
                    newPlants = false;
                }
                else
                {
                    restSum += currenLily + currRose;
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                    newPlants = true;
                }
            }
            while (restSum>=15)
            {
                whreats++;
                restSum -= 15;
            }
            if (whreats>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {whreats} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-whreats} wreaths more!");
            }
        }
    }
}
