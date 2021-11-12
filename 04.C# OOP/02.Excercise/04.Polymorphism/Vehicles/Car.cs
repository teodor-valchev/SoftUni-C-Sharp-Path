using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsmumption)
            : base(fuelQuantity, fuelConsmumption)
        {
        }

        public override double FuelConsmumption => base.FuelConsmumption + 0.9;

        public override void Drive(double distance)
        {

            if (FuelQuantity > distance * FuelConsmumption)
            {
                FuelQuantity -= distance * FuelConsmumption;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
            }
        }

        public override void Refuel(double litters)
        {
            base.Refuel(litters);
        }


    }
}
