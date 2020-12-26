using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            printNumber(n);
        }

        static void printNumber (int number)
        {
            if (number>0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number<0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else if(number==0)
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }
}




    }

