
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WarriorConstructorNameSetCorrectly()
        {
            var warrior = new Warrior("Sancho", 44, 22);
            Assert.AreEqual("Sancho", warrior.Name);
        }
        [Test]
        public void WarriorConstructorDamageSetCorrectly()
        {
            var warrior = new Warrior("Sancho", 44, 22);
            Assert.AreEqual(44, warrior.Damage);
        }
        [Test]
        public void WarriorConstructorHealthSetCorrectly()
        {
            var warrior = new Warrior("Sancho", 44, 22);
            Assert.AreEqual(22, warrior.HP);
        }
        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void WarriorConstructorNameShouldThrowExceptionWhenNull(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 33, 11));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-12)]
        public void WarriorConstructorDamageShouldThrowExceptionWhenNegativeOrZero(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Gosho", damage, 11));
        }
        [Test]
        public void WarriorConstructorHealthShouldThrowExceptionWhenNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Sancho", 33, -11));
        }

        [Test]
        [TestCase(23)]
        [TestCase(30)]
        public void WarriorAtackMethodShouldThrowExceptionWhenHpisBellowMinHp(int hp)
        {
            var warrior = new Warrior("pesho", 22, hp);           
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior));
        }
        [Test]
        [TestCase(23)]
        [TestCase(30)]
        public void WarriorAtackMethodShouldThrowExceptionWhenHpisBellowMinHpAndWhanToAtackAntoher(int hp)
        {
            var attackWarrior = new Warrior("pesho", 22, 55);
            var enemy = new Warrior("dimo", 42, hp);
            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(enemy));
        }
        [Test]
    
        public void WarriorAtackMethodShouldThrowExceptionWhenTryingToAttacToStrongEnemy()
        {
            var attackWarrior = new Warrior("pesho", 22, 40);
            var enemy = new Warrior("dimo", 50, 33);
            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(enemy));
        }
        [Test]

        public void WarriorAtackMethodShouldDecraseEnemyHp()
        {
            var attackWarrior = new Warrior("pesho", 10, 40);
            var enemy = new Warrior("dimo", 2, 50);
            attackWarrior.Attack(enemy);
            Assert.AreEqual(40, enemy.HP);
        }
        [Test]

        public void WarriorAtackMethodShouldKillEnemy()
        {
            var attackWarrior = new Warrior("pesho", 60, 40);
            var enemy = new Warrior("dimo", 2, 50);
            attackWarrior.Attack(enemy);
            Assert.AreEqual(0, enemy.HP);
        }
    }
}
