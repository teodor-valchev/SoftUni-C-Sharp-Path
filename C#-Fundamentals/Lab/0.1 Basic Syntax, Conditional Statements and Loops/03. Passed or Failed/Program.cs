using System;

namespace _03._Passed_or_Failed
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade < 3)
            {
                Console.WriteLine("Failed!");
            }
            else if (grade>2.99)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
