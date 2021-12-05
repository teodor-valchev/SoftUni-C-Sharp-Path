namespace Robots.Tests
{
    using NUnit.Framework;
    using System;


    public class RobotsTests
    {

        [Test]
        public void CapacityExc()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-3));

        }

        [Test]
        public void AddRobotExceptionWhenWithSameName()
        {
            var robotManager = new RobotManager(3);
            var robot = new Robot("pesho", 3);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
                robotManager.Add(robot);

            });
        }

        [Test]
        public void AddRobotExceptionWhenCapacityIsFull()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("pesho", 3);
            var robot2 = new Robot("mimtko", 33);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
                robotManager.Add(robot2);
            });
        }

        [Test]
        public void AddRobotShouldWork()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("pesho", 3);
            robotManager.Add(robot);
            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RemoveRobotShoulThrowExceptionWhenNotFound()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("pesho", 3);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("PESHO"));
        }
        [Test]
        public void RemoveRobotShouldWork()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("pesho", 3);
            robotManager.Add(robot);
            robotManager.Remove("pesho");
            Assert.AreEqual(0, robotManager.Count);
        }
        [Test]
        public void WorkMethodShouldThrowExceptionWhenRobotNull()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("pesho", 3);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(null,"wash",40));

        }
        [Test]
        public void WorkMethodShouldThrowExceptionBatteryIsLowerThanUsageBattery()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("pesho", 3);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("pesho", "wash", 40));

        }
        [Test]
        public void WorkMethodShouldWork()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("pesho", 10);
            robotManager.Add(robot);
            robotManager.Work("pesho", "wash", 5);
            Assert.AreEqual(5, robot.Battery);

        }
        [Test]
        public void ChargeMethodShouldThrowExceptionWhenRobotNull()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("pesho", 3);
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(null));

        }
        [Test]
        public void ChargeMethodShouldWork()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("pesho",100);
            robotManager.Add(robot);
            robotManager.Work("pesho", "wash", 50);
            robotManager.Charge("pesho");
            Assert.AreEqual(100, robot.MaximumBattery);

        }
    }
}
