using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
           string operation = Console.ReadLine();
            double n2 = double.Parse(Console.ReadLine());

            double result = Calculate(n, operation, n2);
           



        }

        private static double Calculate(double n, string operation, double n2)
        {
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = n + n2;
                    Console.WriteLine($"{result}");
                    break;
                case "-":
                    result = n - n2;
                    Console.WriteLine($"{result}");
                    break;
                case "*":
                    result = n * n2;
                    Console.WriteLine($"{result}");
                    break;
                case "/":
                    result = n / n2;
                    Console.WriteLine($"{result}");
                    break;

                default:
                    break;
            }
            return result;
        }
    }
}
