using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void NameTestExc()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 55));
        }
        [Test]
        public void NameTest()
        {
            var gym = new Gym("one", 22);
            Assert.AreEqual("one", gym.Name);
            
        }
        [Test]
        public void CapavityTestExc()
        {
           
            Assert.Throws<ArgumentException>(() => new Gym("one", -55));
        }
        [Test]
        public void CapacitytEST()
        {
            var gym = new Gym("one", 22);
            Assert.AreEqual(22, gym.Capacity);

        }
        [Test]
        public void AddAthleteExc()
        {
            var gym = new Gym("one", 0);
            var athlete = new Athlete("pesho");
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));

        }
        [Test]
        public void AddAthlete()
        {
            var gym = new Gym("one", 2);
            var athlete = new Athlete("pesho");
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);

        }
        [Test]
        public void RemoveAthleteExc()
        {
            var gym = new Gym("one", 4);
            var athlete = new Athlete("pesho");
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("dido"));

        }
        [Test]
        public void RemoveAthlete()
        {
            var gym = new Gym("one", 4);
            var athlete = new Athlete("pesho");
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("pesho");
            Assert.AreEqual(0, gym.Count);


        }
        [Test]
        public void InjuredAthleteExc()
        {
            var gym = new Gym("one", 4);
            var athlete = new Athlete("pesho");
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("dido"));

        }
        [Test]
        public void InjuredAthleteTest()
        {
            var gym = new Gym("one", 4);
            var athlete = new Athlete("pesho");
            gym.AddAthlete(athlete);
            var res = gym.InjureAthlete("pesho");
            Assert.AreEqual(athlete, res);

        }
        [Test]
        public void Repost()
        {
            var gym = new Gym("one", 4);
            var athlete = new Athlete("pesho");
            gym.AddAthlete(athlete);
            var res = gym.Report();
            Assert.AreEqual($"Active athletes at {gym.Name}: {athlete.FullName}", res);

        }

    }
}