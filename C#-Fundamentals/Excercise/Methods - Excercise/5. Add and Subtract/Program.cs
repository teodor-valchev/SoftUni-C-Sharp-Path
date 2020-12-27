using System;

namespace _5._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int sum = Sum(n1, n2, n3);

            Console.WriteLine(sum);
        }

        private static int Sum(int n1, int n2, int n3)
        {
            int SumFirsAndSecond = n1 + n2;

            return Subtract(SumFirsAndSecond, n3);
        }

        private static int Subtract(int sumFirsAndSecond, int n3)
        {
            return sumFirsAndSecond - n3;
        }
    }
}
