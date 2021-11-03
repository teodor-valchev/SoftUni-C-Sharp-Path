using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
      
        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();       
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public List<Topping> Toppings { get; private set; }

        public Dough Dough { get; set; }

        public double TotalCalories => Dough.Calories + Toppings.Sum(x => x.Calories);

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count>10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            Toppings.Add(topping);
        }


      
    }
}
