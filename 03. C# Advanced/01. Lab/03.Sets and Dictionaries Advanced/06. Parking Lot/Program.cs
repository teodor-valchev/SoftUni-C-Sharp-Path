using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(", ");
                string cmd = tokens[0];
                string car = tokens[1];

                if (cmd == "IN")
                {
                    cars.Add(car);
                }
                else if (cmd == "OUT")
                {
                    cars.Remove(car);
                }


                command = Console.ReadLine();
            }
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
