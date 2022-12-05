using System;

namespace PizzaCalories
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try {
                string[] pizzaName = Console.ReadLine().Split();
                string name = pizzaName[1];
                Pizza pizza = new Pizza(name);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] tokkens = command.Split();
                    string ingrident = tokkens[0];

                    if (ingrident == "Dough")
                    {
                        Dough dough = new Dough(tokkens[1], tokkens[2], int.Parse(tokkens[3]));
                        pizza.Dough = dough;

                    }
                    else if (ingrident == "Topping")
                    {
                        Topping topping = new Topping(tokkens[1], double.Parse(tokkens[2]));
                        pizza.AddTopping(topping);
                    }


                    command = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
