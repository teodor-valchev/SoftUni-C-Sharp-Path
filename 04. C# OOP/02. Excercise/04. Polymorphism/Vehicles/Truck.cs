using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsmumption) 
            : base(fuelQuantity, fuelConsmumption)
        {
        }

        public override double FuelConsmumption => base.FuelConsmumption + 1.6;

        public override  void Drive(double distance)
        {
            if (FuelQuantity > distance * FuelConsmumption)
            {
                FuelQuantity -= distance * FuelConsmumption;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
            }

        }

        public override void Refuel(double litters)
        {
             
            base.Refuel(litters*0.95);
        }
    }
}
