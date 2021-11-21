using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddItemCellShoudlNotExist()
        {
            var bank = new BankVault();

            Assert.Throws<ArgumentException>(() =>
            {
                bank.AddItem("A100", new Item("pes", "www"));
            });
        }

        [Test]
        public void AddItemCellIsTaken()
        {
            var bank = new BankVault();
         
            Assert.Throws<ArgumentException>(() =>
            {
                bank.AddItem("A3", new Item("dd","eee"));
                bank.AddItem("A3", new Item("dd", "eee"));

            });
        }


        [Test]
        public void AddItemCellWithSameId()
        {
            var bank = new BankVault();
            Assert.Throws<InvalidOperationException>(() =>
            {
                bank.AddItem("A4", new Item("pesd","22"));
                bank.AddItem("A3", new Item("dd", "22"));

            });
        }

        [Test]
        public void AddItemCellSucces()
        {
            var bank = new BankVault();
          var result =  bank.AddItem("A4", new Item("pesd", "22"));

            Assert.AreEqual("Item:22 saved successfully!", result);
        }

        [Test]
        public void RemoveCellShoudlNotExist()
        {
            var bank = new BankVault();

            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("A100", new Item("pes", "www"));
            });
        }

        [Test]
        public void RemoveCellIDoesntExist()
        {
            var bank = new BankVault();

            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("A3", new Item("dd", "eee"));
                bank.RemoveItem("A3", new Item("dd", "eee"));

            });
        }

        [Test]
        public void RemoveItemSucces()
        {
            var bank = new BankVault();
            var item = new Item("pesd", "22");
            bank.AddItem("A4",item );
            var result = bank.RemoveItem("A4", item);
            Assert.AreEqual("Remove item:22 successfully!", result);
        }

    }
}