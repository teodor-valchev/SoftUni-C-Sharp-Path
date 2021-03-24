using System;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numberOfHearts = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries);

            string command = Console.ReadLine();

            while (command!="Love!")
            {
              


                command = Console.ReadLine();
            }
                
        }
    }
}
