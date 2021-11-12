using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsmumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsmumption = fuelConsmumption;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsmumption { get; set; }

        public virtual void Drive(double distance)
        {
            if (FuelQuantity > distance * FuelConsmumption)
            {
                FuelQuantity -= distance * FuelConsmumption;
                
            }

             
        }

        public virtual void Refuel(double litters)
        {
            FuelQuantity += litters;
        }
    }
}
