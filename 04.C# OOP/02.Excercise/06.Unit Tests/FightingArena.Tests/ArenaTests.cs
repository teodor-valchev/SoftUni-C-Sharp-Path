
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionWhenSameWarriorExcist()
        {
            var arena = new Arena();
            var warrior = new Warrior("pesho", 44, 50);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));           
        }
        [Test]
        public void EnrollMethodShouldWork()
        {
            var arena = new Arena();
            var warrior = new Warrior("pesho", 44, 50);
            arena.Enroll(warrior);
            Assert.AreEqual(1, arena.Count);
        }
        [Test]
        public void FightMethodShouldThrowExceptionWhenCannotFindNames()
        {
            var arena = new Arena();
            Assert.Throws<InvalidOperationException>(() => arena.Fight(null, null));
        }
        [Test]
        public void FightMethodShouldThrowExceptionWhenFirstWarriorCantFindAnohter()
        {
            var arena = new Arena();
            var warrior = new Warrior("pesho", 10, 50);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("pesho", null));
        }
        [Test]
        public void FightMethodShouldWork()
        {
            var arena = new Arena();
            var warrior = new Warrior("pesho", 10, 50);
            var warriorTwo = new Warrior("gosho", 2, 40);
            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);
            arena.Fight("pesho", "gosho");
            Assert.AreEqual(30, warriorTwo.HP);
        }
    }
}
