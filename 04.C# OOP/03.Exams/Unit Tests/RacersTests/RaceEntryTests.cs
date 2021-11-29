using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DriverCannotBeNull()
        {
            var race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }
        [Test]
        public void DriverWithTheSameNameCannotBeInTheRace()
        {
            var race = new RaceEntry();
            var unitCar = new UnitCar("s", 2, 5);
            var driver = new UnitDriver("pesho", unitCar);
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
                race.AddDriver(driver);
            });
        }

        [Test]
        public void DriverAddedToRace()
        {
            var race = new RaceEntry();
            var unitCar = new UnitCar("s", 2, 5);
            var driver = new UnitDriver("pesho", unitCar);
            var result = race.AddDriver(driver);
            Assert.AreEqual("Driver pesho added in race.", result);
        }

        [Test]
        public void CalcculateminNumberParticipents()
        {
            var race = new RaceEntry();
            var unitCar = new UnitCar("s", 2, 5);
            var driver = new UnitDriver("pesho", unitCar);
            race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            }
            );
        }

        [Test]
        public void CalcculateShoudWorkd()
        {
            var race = new RaceEntry();
            var unitCar = new UnitCar("s", 10, 5);
            var driver = new UnitDriver("pesho", unitCar);
            var unitCar2 = new UnitCar("ses", 10, 5);
            var driver2 = new UnitDriver("peshos", unitCar2);
            race.AddDriver(driver);
            race.AddDriver(driver2);
            var result = race.CalculateAverageHorsePower();
            Assert.AreEqual(10, result);
        }
    }
}
