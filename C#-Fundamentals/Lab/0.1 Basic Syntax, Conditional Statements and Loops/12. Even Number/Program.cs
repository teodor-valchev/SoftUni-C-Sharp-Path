﻿using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            do
            {
                if (n % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(n)}");
                    break;

                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                    n = int.Parse(Console.ReadLine());
                }
            } while (n != 0);
        }
    }
}
