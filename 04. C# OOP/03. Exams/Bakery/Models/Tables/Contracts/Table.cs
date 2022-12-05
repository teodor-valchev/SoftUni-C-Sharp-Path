using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables.Contracts
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;

        protected Table(int tableNumber, int capacity)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                capacity = value;
            }

        }

        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                numberOfPeople = value;
            }

        }

        public virtual decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => numberOfPeople * PricePerPerson;

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            IsReserved = false;
            numberOfPeople = 0;

        }

        public decimal GetBill()
        {
            decimal bill = 0;

            foreach (var item in FoodOrders)
            {
                bill += item.Price;
            }

            foreach (var item in DrinkOrders)
            {
                bill += item.Price;
            }
            return bill += Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().TrimEnd();

        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
