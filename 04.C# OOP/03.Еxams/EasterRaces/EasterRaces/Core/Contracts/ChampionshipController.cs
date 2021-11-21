using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Contracts
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> driverRepository = new DriverRepository();
        private IRepository<ICar> carRepository = new CarRepository();
        private IRepository<IRace> raceRepository = new RaceRepository();
        public ChampionshipController()
        {

        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driverExist = driverRepository.GetByName(driverName);
            if (driverExist == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            var carExist = carRepository.GetByName(carModel);
            if (carExist == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            ICar car = carRepository.GetByName(carModel);
            IDriver driver = driverRepository.GetByName(driverName);
            driver.AddCar(car);
            return string.Format(string.Format(OutputMessages.CarAdded, driverName, carModel));
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var raceExist = raceRepository.GetByName(raceName);
            if (raceExist == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            var driverExist = driverRepository.GetByName(driverName);
            if (driverExist == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            IDriver driver = driverRepository.GetByName(driverName);
            IRace race = raceRepository.GetByName(raceName);
            race.AddDriver(driver);
            return string.Format(string.Format(OutputMessages.DriverAdded, driverName, raceName));
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
                var existCar = carRepository.GetByName(model);
                if (existCar != null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
                } 
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
                var existCar = carRepository.GetByName(model);
                if (existCar != null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
                }
            }
            carRepository.Add(car);
            return (string.Format(string.Format(OutputMessages.CarCreated, type, model)));
        }

        public string CreateDriver(string driverName)
        {
            var driverExist = driverRepository.GetByName(driverName);
            if (driverExist != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            var driver = new Driver(driverName);
            driverRepository.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }
        public string CreateRace(string name, int laps)
        {
            var existRace = raceRepository.GetByName(name);
            if (existRace != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            var race = new Race(name, laps);
            raceRepository.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }
        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid,raceName,3));
            }
            var drivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();
            var first = drivers.FirstOrDefault();
            var second = drivers.Skip(1).FirstOrDefault();
            var third = drivers.Skip(2).FirstOrDefault();
            StringBuilder sb = new StringBuilder();
    
            sb.AppendLine($"Driver {first.Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {second.Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {third.Name} is third in {race.Name} race.");
            var res = sb.ToString().TrimEnd();
            raceRepository.Remove(race);


            return res;
        }
    }
}
