using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsmumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsmumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
          
            if (FuelQuantity > distance * FuelConsmumption)
            {
                FuelQuantity -= distance * FuelConsmumption;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Bus needs refueling");
            }
        }

        public override void Refuel(double litters)
        {
            base.Refuel(litters);
        }
    }
}
