using System;

namespace _03._Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int timeForDeposit = int.Parse(Console.ReadLine());
            double yearlyProcent = double.Parse(Console.ReadLine());

            double naturalPlus =  depositSum * (yearlyProcent/100);
            double monthlyProcent = naturalPlus / 12;
            double result = depositSum + (timeForDeposit * (timeForDeposit * monthlyProcent));
            Console.WriteLine(result);
        }
    }
}
