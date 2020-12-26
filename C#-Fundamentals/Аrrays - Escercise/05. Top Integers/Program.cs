using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            bool isBigger = true;

            for (int i = 0; i < arr.Length; i++)
            {
                int curenntint = arr[i];
                for (int j = i+1; j < arr.Length; j++)// слагам i+1 за да вземем втория елемент иначе ако не го сложим ще взема curenntint!!
                {
                    if (arr[j]>=curenntint)
                    {
                        isBigger = false;
                        break;
                    }
                }
                if (isBigger)
                {
                    Console.Write(curenntint + " ");
                }
                isBigger = true;

            }
            
        }
    }
}
