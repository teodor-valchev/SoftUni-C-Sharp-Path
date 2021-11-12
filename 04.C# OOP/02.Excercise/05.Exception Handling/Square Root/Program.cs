using System;

namespace Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double n = double.Parse(Console.ReadLine());
                if (n <= 0)
                {
                    throw new ArgumentException("Invalid number");
                }
                double squareRoot = Math.Sqrt(n);
                Console.WriteLine(squareRoot);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
