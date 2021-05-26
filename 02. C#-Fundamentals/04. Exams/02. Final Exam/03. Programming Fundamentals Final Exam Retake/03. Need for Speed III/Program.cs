using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> cars = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split("|");
                string car = tokens[0];
                int mileage = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);

                if (!cars.ContainsKey(car))
                {
                    cars.Add(car, new Dictionary<string, int>()
                    {
                        {"mileage",mileage },
                        {"fuel",fuel }
                    });
                }


            }

            string command = Console.ReadLine();

            while (command!="Stop")
            {
                string[] tokens = command
                   .Split(" : ");
                string name = tokens[0];
                string car = tokens[1];

                if (name == "Drive")
                {
                    int distance = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);

                    if (cars[car]["fuel"]<fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car]["mileage"] += distance;
                        cars[car]["fuel"] -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (cars[car]["mileage"]> 100000 )
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.Remove(car);
                    }
                }
                else if (name== "Refuel")
                {
                    int fuel = int.Parse(tokens[2]);
                    int current = cars[car]["fuel"];
                    cars[car]["fuel"] += fuel;
                    int maxFuel = 75;

                    if (cars[car]["fuel"]>75)
                    {
                        cars[car]["fuel"] = maxFuel;
                        Console.WriteLine($"{car} refueled with {maxFuel - current} liters");
                        command = Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (name == "Revert")
                {
                    int kilometers = int.Parse(tokens[2]);
                    cars[car]["mileage"] -= kilometers;
                    Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");

                    if (cars[car]["mileage"]< 10000)
                    {
                        cars[car]["mileage"] = 10000;
                    }

                }

                command = Console.ReadLine();
            }

            cars = cars.OrderByDescending(c => c.Value["mileage"])
                .ThenBy(c => c.Key)
                .ToDictionary(k=>k.Key,v=>v.Value);

            foreach (var car in cars)
            {
                int mileage = car.Value["mileage"];
                int fuel = car.Value["fuel"];
                Console.WriteLine($"{car.Key} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt.");
            }

        }
    }
}
