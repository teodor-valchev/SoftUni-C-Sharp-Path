using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string [] num1 = new string[n];
            string [] num2 = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentArray = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string indexZeroElemnt = currentArray[0];
                string indexElement = currentArray[1];
                // even iteration
                if (i%2==0)
                {
                    num1[i] = indexZeroElemnt;
                    num2[i] = indexElement;
                }
                // odd iteration
                else if (i%2==1)
                {
                    num1[i] = indexElement;
                    num2[i] = indexZeroElemnt;
                }
              
            }
            Console.WriteLine(string.Join(" ",num1));
            Console.WriteLine(string.Join(" ", num2));

        }
    }
}
