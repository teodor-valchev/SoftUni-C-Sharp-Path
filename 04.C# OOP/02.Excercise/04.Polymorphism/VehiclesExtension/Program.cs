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
            int tankCapacity = int.Parse(carInfo[3]);
            IVehicle car = new Car(fuelQuantity, fuelConsumption, tankCapacity);

            string[] truckInfo = Console.ReadLine().Split();
            double fuelQuantityForTruck = double.Parse(truckInfo[1]);
            double fuelConsumptionForTruck = double.Parse(truckInfo[2]);
            int truckTankCapacity = int.Parse(truckInfo[3]);
            IVehicle truck = new Truck(fuelQuantityForTruck, fuelConsumptionForTruck, truckTankCapacity);

            string[] busInfo = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            int busTankCapacity = int.Parse(busInfo[3]);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);


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
                    else if (vehicleType == "Bus")
                    {
                        double distance = double.Parse(info[2]);
                        bus.FuelConsmumption += 1.4;
                        bus.Drive(distance);
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
                    else if (vehicleType == "Bus")
                    {
                        double litters = double.Parse(info[2]);
                        bus.Refuel(litters);
                    }

                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(info[2]);
                    bus.Drive(distance);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
