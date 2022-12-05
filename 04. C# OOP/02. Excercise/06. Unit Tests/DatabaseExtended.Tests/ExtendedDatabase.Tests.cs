
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PersonConstructorShouldWorkName()
        {
            var person = new Person(22, "papi");
            Assert.AreEqual(22, person.Id);
        }

        [Test]
        public void PersonConstructorShouldWorkId()
        {
            var person = new Person(22, "papi");
            Assert.AreEqual("papi", person.UserName);
        }

        [Test]
        [TestCase(18)]
        [TestCase(166)]

        public void AddMethodExeption(int count)
        {
            Person[] data = new Person[count];

            Assert.Throws<ArgumentException>(() =>
            {
                var extended = new ExtendedDatabase(data);
            });

        }


        [Test]     
        public void AddMethodForPersonCannotBeEqualTo16()
        {
            var extended = new ExtendedDatabase();      
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i <= 16; i++)
                {
                    Person person = new Person(i, "d" + i);
                    extended.Add(person);
                }
            });      
        }


        [Test]
        public void AddMethodForPersonCannotBeTheSamePersonName()
        {
            var extended = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i <= 16; i++)
                {
                    Person person = new Person(i,"d");
                    extended.Add(person);
                }
            });
        }
        [Test]
        public void AddMethodForPersonCannotBeTheSamePersonId()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i <= 16; i++)
                {
                    Person person = new Person(1, "d");
                    database.Add(person);
                }
            });
        }

        [Test]
        public void AddMethodForPersosonCounterCheck()
        {
            ExtendedDatabase database = new ExtendedDatabase();
            Person person = new Person(2, "dedo");
            database.Add(person);

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void RangeMethodCannotBeOver16()
        {
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(new Person[17]));  
        }
        [Test]
        public void CountShouldIncrease()
        {
           
            var extended = new ExtendedDatabase();
            Person person = new Person(2, "Pesho");
            extended.Add(person);
            Assert.AreEqual(1, extended.Count);
        }

        [Test]
        public void RemoveMethodThrowExceptionWhen0()
        {

            var extended = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => extended.Remove());
        }

        [Test]
        public void RemoveMethodShouldWork()
        {

            var extended = new ExtendedDatabase();
            var person = new Person(2, "dedo");
            Assert.AreEqual(0, extended.Count);
        }


        [Test]
        public void FindUsernameShouldThrowExceptionWhenNULL()
        {

            var extended = new ExtendedDatabase();
            var person = new Person(2, null);
            Assert.Throws<ArgumentNullException>(() => extended.FindByUsername(null));
        }


        [Test]
        public void FindUsernameShouldThrowExceptionWhenCannotFindThePerson()
        {

            var extended = new ExtendedDatabase();
            var person = new Person(2, "pepo");
            extended.Add(person);
            Assert.Throws<InvalidOperationException>(() => extended.FindByUsername("kolio"));
        }
        [Test]
        public void FindUsernameShouldWork()
        {

            var extended = new ExtendedDatabase();
            var person = new Person(2, "pepo");
            extended.Add(person);
            var result = extended.FindByUsername("pepo");
            Assert.AreEqual(person, result);
        }

        [Test]
        public void FindIdThrowExceptionWhenNegative()
        {

            var extended = new ExtendedDatabase();
            Assert.Throws<ArgumentOutOfRangeException>(() => extended.FindById(-22));
        }

        [Test]
        public void FindIdThrowExceptionWhenIsNotFound()
        {

            var extended = new ExtendedDatabase();
            var person = new Person(11, "pepo");
            extended.Add(person);
            Assert.Throws<InvalidOperationException>(() => extended.FindById(13));
        }
        [Test]
        public void FindIdShouldWork()
        {

            var extended = new ExtendedDatabase();
            var person = new Person(2, "pepo");
            extended.Add(person);
            var result = extended.FindById(2);
            Assert.AreEqual(person, result);
        }


    }
}