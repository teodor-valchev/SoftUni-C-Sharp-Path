using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehaviour;
        private int drivingExpiriance;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }


        public string Username
        {
            get => username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                username = value;
            }
        }
        public string RacingBehavior
        {
            get => racingBehaviour;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }
                racingBehaviour = value;
            }
        }

        public int DrivingExperience
        {
            get => drivingExpiriance;

            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }
                drivingExpiriance = value;
            }
        }

        public ICar Car
        {
            get => car;

            private set
            {
                if (value==null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }
                car = value;
            }
        }


        public bool IsAvailable() => car.FuelAvailable > car.FuelConsumptionPerRace;
        

        public virtual void Race()
        {
            car.Drive();
        }
    }
}
