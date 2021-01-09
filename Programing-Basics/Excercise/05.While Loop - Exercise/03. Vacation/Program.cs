using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double target = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int daysCounter = 0;
            double spendMoneyCounter = 0;
            bool isEnough = false;

            while (!isEnough)
            {
                string comand = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                daysCounter++;
                if (comand=="save")
                {
                    budget += money;
                    spendMoneyCounter = 0;
                }
                else
                {
                    budget -= money;

                    if (budget<0)
                    {
                        budget = 0;
                    }

                    spendMoneyCounter++;
                    if (spendMoneyCounter>=5)
                    {
                        break;
                    }

                }
                if (budget>=target)
                {
                    isEnough = true;
                }
            }
            if (isEnough)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{daysCounter}");
            }
        }
    }
}
