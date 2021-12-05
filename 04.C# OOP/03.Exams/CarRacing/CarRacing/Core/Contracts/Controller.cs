using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }



        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }

            else if (type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }

            cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer = null;
            ICar racersCar = cars.FindBy(carVIN);

            if (type == nameof(ProfessionalRacer))
            {
                if (racersCar == null)
                {
                    throw new ArgumentException("Car cannot be found!");
                }
                racer = new ProfessionalRacer(username,racersCar);
            }
            else if (type == nameof(StreetRacer))
            {
                if (racersCar == null)
                {
                    throw new ArgumentException("Car cannot be found!");
                }
                racer = new StreetRacer(username, racersCar);
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }

            racers.Add(racer);
            return $"Successfully added racer {username}.";

        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var firstRacer = racers.FindBy(racerOneUsername);
            var secondRacer = racers.FindBy(racerTwoUsername);

            if (firstRacer == null)
            {
                throw new ArgumentException($"Racer {firstRacer.Username} cannot be found!");
            }
            if (secondRacer == null)
            {
                throw new ArgumentException($"Racer {secondRacer.Username} cannot be found!");
            }
            return map.StartRace(firstRacer, secondRacer);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var orderedList = racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username).ToList();

            foreach (var racer in orderedList)
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
