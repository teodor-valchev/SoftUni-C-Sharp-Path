using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private int tankCapacity;
        protected Vehicle(double fuelQuantity, double fuelConsmumption, int tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsmumption = fuelConsmumption;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsmumption { get; set; }
        public int TankCapacity
        {

            get
            {
                return tankCapacity;
            }
            set
            {
                if (FuelQuantity > value)
                {
                    tankCapacity = 0;
                }
                else
                {
                    tankCapacity = value;
                }

            }
        }

        public virtual void Drive(double distance)
        {
            if (FuelQuantity > distance * FuelConsmumption)
            {
                FuelQuantity -= distance * FuelConsmumption;
            }
        }

        public virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + litters > tankCapacity)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
            }
            else
            {
                FuelQuantity += litters;
            }
        }
    }
}
