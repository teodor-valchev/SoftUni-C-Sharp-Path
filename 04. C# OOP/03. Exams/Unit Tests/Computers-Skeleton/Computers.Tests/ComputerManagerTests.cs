using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddMethodCompCannotBeNull()
        {
            var compManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() => compManager.AddComputer(null));
        }
        [Test]
        public void AddMethodCompCannotBeSame()
        {
            var compManager = new ComputerManager();
            var comp = new Computer("hp", "soul", 44);
            Assert.Throws<ArgumentException>(() =>
            {
                compManager.AddComputer(comp);
                compManager.AddComputer(comp);

            });
        }
        [Test]
        public void AddMethodShouldWork()
        {
            var compManager = new ComputerManager();
            var comp = new Computer("hp", "soul", 44);
            compManager.AddComputer(comp);
            Assert.AreEqual(1, compManager.Count);
        }
        [Test]
        public void RemoveMethodShouldWork()
        {
            var compManager = new ComputerManager();
            var comp = new Computer("hp", "soul", 44);
            compManager.AddComputer(comp);
            compManager.RemoveComputer("hp", "soul");
            Assert.AreEqual(0, compManager.Count);
        }
        [Test]
        public void RemoveMethodShoudThrowExceptionWhenModelIsNull()
        {
            var compManager = new ComputerManager();
            var comp = new Computer("hp", null, 44);
            compManager.AddComputer(comp);
            Assert.Throws<ArgumentNullException>(() => compManager.RemoveComputer("hp", null));
        }
        [Test]
        public void RemoveMethodShoudThrowExceptionWhenCannotFindComp()
        {
            var compManager = new ComputerManager();
            var comp = new Computer("hp", null, 44);
            compManager.AddComputer(comp);
            Assert.Throws<ArgumentException>(() => compManager.RemoveComputer("hp", "pesho"));
        }
        [Test]
        public void GetCompByManufacturerShouldWork()
        {
            var compManager = new ComputerManager();
            var comp = new Computer("hp", "big", 44);
            var comp2 = new Computer("hp", "ss", 422);
            var comp3 = new Computer("hpsss", "ss", 422);
            compManager.AddComputer(comp);
            compManager.AddComputer(comp2);
          var res =  compManager.GetComputersByManufacturer("hp");
            Assert.AreEqual(2, res.Count);

        }
        [Test]
        public void GetCompModelShouldThrowException()
        {
            var compManager = new ComputerManager();
            var comp = new Computer("hp", "big", 44);
            compManager.AddComputer(comp);
            Assert.Throws<ArgumentException>(() => compManager.GetComputer("pes", "big"));
            
        }

    }
}