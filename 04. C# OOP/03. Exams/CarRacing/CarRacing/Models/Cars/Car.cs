using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvaliable;
        private double fuelConsumption;

        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            this.VIN = VIN;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public string Make
        {
            get => make;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }
                make = value;
            }
        }

        public string Model
        {
            get => model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }
                model = value;
            }
        }

        public string VIN
        {
            get => vin;

            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                vin = value;
            }
        }


        public int HorsePower
        {
            get => horsePower;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }
                horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => fuelAvaliable;

            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                fuelAvaliable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => fuelConsumption;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
                fuelConsumption = value;
            }
        }

        public virtual void Drive()
        {
            fuelAvaliable -= FuelConsumptionPerRace;
        }
    }
}
