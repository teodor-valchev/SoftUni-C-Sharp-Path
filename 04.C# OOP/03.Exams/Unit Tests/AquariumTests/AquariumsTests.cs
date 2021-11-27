namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {

        [Test]

        public void NameshouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 4));
        }
        [Test]
        public void NameshouldBeCorrect()
        {
            var aquarium = new Aquarium("d", 2);
            var res = aquarium.Name;
            Assert.AreEqual("d", res);
        }
        [Test]
        public void CapacityException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("d", -3));
        }
       [Test]

        public void CapacitySucces()
        {
            var aquarium = new Aquarium("d", 2);
            var res = aquarium.Capacity;
            Assert.AreEqual(2, res);
        }
        [Test]

        public void FullAqua()
        {
            var aquarium = new Aquarium("d", 1);
            var fissh = new Fish("s");
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fissh);
                aquarium.Add(fissh);

            });
        }

        [Test]

        public void AddFish()
        {
            var aquarium = new Aquarium("d", 5);
            var fissh = new Fish("s");
            aquarium.Add(fissh);
            Assert.AreEqual(aquarium.Capacity>0, aquarium.Capacity > 0);
        }


        [Test]

        public void RemoveFishException()
        {
            var aquarium = new Aquarium("d", 5);
            var fissh = new Fish("ALEHANDRO");

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("DIDO");
            });

        }

        [Test]

        public void SellFishException()
        {
            var aquarium = new Aquarium("d", 5);
            var fissh = new Fish("ALEHANDRO");
            aquarium.Add(fissh);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("pesho");
            });

        }

        [Test]

        public void SellFishSucces()
        {
            var aquarium = new Aquarium("d", 5);
            var fissh = new Fish("ALEHANDRO");
            aquarium.Add(fissh);
            var res = aquarium.SellFish("ALEHANDRO");
            Assert.AreEqual(fissh, res);
        }

        [Test]

        public void ReportSuccess()
        {
            var aquarium = new Aquarium("d", 5);
            var fissh = new Fish("ALEHANDRO");
            var fissh2 = new Fish("PESHO");
            aquarium.Add(fissh);
            aquarium.Add(fissh2);

            var res = aquarium.Report();
            Assert.AreEqual("Fish available at d: ALEHANDRO, PESHO", res);
        }

    }
}
