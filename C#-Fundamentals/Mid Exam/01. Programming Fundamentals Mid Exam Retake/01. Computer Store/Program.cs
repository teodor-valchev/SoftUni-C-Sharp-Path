using System;

namespace _01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {


            string command = Console.ReadLine();
            double totalPricewithoutTaxes = 0;

            while (command != "special" && command != "regular")
            {
                double price = double.Parse(command);


                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                    continue;
                }
                totalPricewithoutTaxes += price;

                command = Console.ReadLine();
            }


            bool succes = false;

            double discount = totalPricewithoutTaxes * 0.2;
            double totalPrice = discount + totalPricewithoutTaxes;
            double final = 0;

            if (command == "special")
            {
                double extraDiscount = totalPrice * 0.1;
                totalPrice -= extraDiscount;
                final += totalPrice;
            }
          
           
            if (final == 0)
            {
                final += totalPrice;
                
            }

            if (final>0)
            {
                succes = true;
            }

            if (succes == false)
            {
                Console.WriteLine("Invalid order!");


            }

            else if (succes == true)
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPricewithoutTaxes:f2}$");
                Console.WriteLine($"Taxes: {discount:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {final:f2}$");
            }
          




        }
    }
}
