using System;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] wagons = new int[n];
            int sum = 0;
            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                sum += wagons[i];
            }

            Console.WriteLine(string.Join(" ",wagons));// за да се отпечатва с space с Join

            Console.WriteLine(sum);
        }
    }
}
