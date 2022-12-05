using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> toppingType = new Dictionary<string, double>()
        {
            { "meat",1.2},
            {"veggies",0.8 },
            {"cheese",1.1 },
            {"sauce",0.9 }
        };
        private string topping;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType
        {
            get
            {
                return topping;
            }
            private set
            {
                if (!toppingType.ContainsKey(value.ToLower()))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                topping = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{topping} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories => 2 * (Weight * toppingType[ToppingType.ToLower()]);
    }
}

