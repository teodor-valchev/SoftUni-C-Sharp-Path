using System;

namespace _02._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

           long result = GetFactoriel(input);
            Console.WriteLine(result);
        }

        private static long GetFactoriel(int input)
        {
           
            if (input == 0)
            {
                return 1;
            }
            return input * GetFactoriel(input-1);
        }
    }
}
