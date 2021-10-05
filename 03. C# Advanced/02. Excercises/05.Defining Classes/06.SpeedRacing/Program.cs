using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public bool Drive(double distance)
        {
            double neededFuel = distance * FuelConsumptionPerKilometer;
            if (neededFuel > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return false;
            }
            FuelAmount -= neededFuel;
            TravelledDistance += distance;


            return true;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carName = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);
                Car car = new Car(carName, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string cmd = Console.ReadLine();

            while (cmd != "End")
            {

                string[] tokens = cmd.Split();
                string carName = tokens[1];
                double distance = double.Parse(tokens[2]);
                Car car = cars.FirstOrDefault(x => x.Model == carName);
                car.Drive(distance);
                cmd = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
