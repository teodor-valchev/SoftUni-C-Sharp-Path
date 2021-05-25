using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            double total = 0.0;
            while (comand!= "NoMoreMoney")
            {
                double money = double.Parse(comand);
               
                if (money <0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                total += money;
                Console.WriteLine($"Increase: {money:f2}");

                comand = Console.ReadLine();
            }
            Console.WriteLine($"Total: {total}");
        }
    }
}
