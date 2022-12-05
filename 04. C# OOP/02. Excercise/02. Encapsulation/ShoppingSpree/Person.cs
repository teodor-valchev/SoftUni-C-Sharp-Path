using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> products;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                name = value;
            }

        }

        public int Money
        {
            get
            {
                return money;
            }


            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                money = value;
            }
        }



        public string ReturnProducts()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                if (products.Count > 1)
                {
                    sb.Append($"{product.Name}, ");
                }
                else
                {
                    sb.Append($"{product.Name}");
                }
            }

            if (products.Count == 0)
            {
                sb.Append("Nothing bought");
            }
            return sb.ToString().TrimEnd(' ').TrimEnd(',');


        }


        public bool AddProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                products.Add(product);
                return true;
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
                return false;
            }
        }
    }
}
