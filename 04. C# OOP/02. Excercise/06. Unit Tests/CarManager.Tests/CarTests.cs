
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CarConstructorShouldWork()
        {
            Car car = new Car("pesho", "nissan",40, 100);
            Assert.AreEqual("pesho", car.Make);
            Assert.AreEqual("nissan", car.Model);
            Assert.AreEqual(40, car.FuelConsumption);
            Assert.AreEqual(100, car.FuelCapacity);
        }
        [Test]
        public void CarConstructorMakeCannotBeNull()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "nissan", 40, 100)); 
          
        }
        [Test]
        public void CarConstructorModelCannotBeNull()
        {
            Assert.Throws<ArgumentException>(() => new Car("pesho", null, 40, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-55)]

        public void CarConstructorFuelConsumotionCannotBeZeroOrLess(int fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("pesho", "nissan", fuelConsumption, 100));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-55)]

        public void CarConstructorFuelCapacityCannotBeZeroOrLess(int fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("pesho", "nissan", 23, fuelCapacity));
        }


        [Test]
        [TestCase(0)]
        [TestCase(-55)]

        public void RefuelMethodCannotBeZeroOrLess(int fuelToRefuel)
        {
            var car = new Car("pesho", "nissan", 23, 12);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        [TestCase(4)]
        [TestCase(10)]
        public void RefuelMethodShoudlIncreaseFuelAmount (int fuelToRefuel)
        {
            var car = new Car("pesho", "nissan", 23, 12);
           car.Refuel(fuelToRefuel);
            Assert.AreEqual(car.FuelAmount, fuelToRefuel);     
        }
        [Test]  
        public void RefuelMethodCheckIfAmountIsBiggerThanCapacity()
        {
            var car = new Car("pesho", "nissan", 23, 2);
            car.Refuel(4);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }
        [Test]
        public void DriveMethodShouldThrowExceptionWhenNeededFuelIsBiggerThanDistance()
        {
            var car = new Car("pesho", "nissan", 23, 2);
            car.Refuel(50);
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

        [Test]
        public void DriveMethodShouldWork()
        {
            var car = new Car("pesho", "nissan", 10, 40);
            car.Refuel(30);
            car.Drive(10);
            Assert.AreEqual(29, car.FuelAmount);
        
        }

    }
}