using System;

namespace _9._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostgames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double money = headsetPrice * (lostgames / 2);
            money += mousePrice * (lostgames / 3);
            money += mousePrice * (lostgames / 6);
            money += mousePrice * (lostgames / 12);
            Console.WriteLine($"Rage expenses {money:f2}lv.");

        }
    }
}
