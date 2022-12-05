using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);
            IVehicle car = new Car(fuelQuantity, fuelConsumption);

            string[] truckInfo = Console.ReadLine().Split();
            double fuelQuantityForTruck = double.Parse(truckInfo[1]);
            double fuelConsumptionForTruck = double.Parse(truckInfo[2]);
            IVehicle truck = new Truck(fuelQuantityForTruck, fuelConsumptionForTruck);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string command = info[0];
                string vehicleType = info[1];

                if (command == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        double distance = double.Parse(info[2]);
                        car.Drive(distance);
                    }
                    else if (vehicleType == "Truck")
                    {
                        double distance = double.Parse(info[2]);
                        truck.Drive(distance);
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        double litters = double.Parse(info[2]);
                        car.Refuel(litters);
                    }
                    else if (vehicleType == "Truck")
                    {
                        double litters = double.Parse(info[2]);
                        truck.Refuel(litters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");

        }
    }
}
