using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = Sum(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(sum);
        }

        private static int Sum(int firstNumber, int secondNumber, int thirdNumber)
        {
            int sumFirstAndSecond = firstNumber + secondNumber;

            return Subtractt(sumFirstAndSecond, thirdNumber);
        }

        private static int Subtractt(int sumFirstAndSecond, int thirdNumber)
        {
            sumFirstAndSecond -= thirdNumber;
            return sumFirstAndSecond;
        }
    }
}
