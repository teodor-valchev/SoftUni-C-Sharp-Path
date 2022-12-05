
using NUnit.Framework;
using System;

namespace Tests
// return to Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]     
        public void DatabaseMethodAddShuoldntBeBigger16()
        {
            Database data = new Database();      
            Assert.Throws<InvalidOperationException>(() => 
            {
                int[] datas = new int[17];
                for (int i = 0; i < datas.Length; i++)
                {
                    data.Add(i);
                }
            });
        }
        [Test]
        public void DatabaseMethodAddMethodShouldWork()
        {
           Database data = new Database();
            data.Add(3);
            Assert.AreEqual(1, data.Count);
        }
        [Test]
        public void DatabaseRemoveMethodThrowsException()
        {
           Database data = new Database();
            Assert.Throws<InvalidOperationException>(() => data.Remove());
            
        }
        [Test]
        public void DatabaseRemoveMethodShouldReduceCount()
        {
         Database data = new Database();
            data.Add(3);
            data.Add(2);
            data.Add(1);
            data.Add(4);

            data.Remove();
            data.Remove();

            Assert.AreEqual(2, data.Count);

        }

        [Test]
        public void DatabaseFetchMethodShouldWork()
        {
           Database data = new Database();
            data.Add(3);
            data.Add(2);
            data.Add(1);
            data.Add(4);
        var datas = data.Fetch();           
            Assert.AreEqual(data.Fetch(), datas);
        }
  
    }
}