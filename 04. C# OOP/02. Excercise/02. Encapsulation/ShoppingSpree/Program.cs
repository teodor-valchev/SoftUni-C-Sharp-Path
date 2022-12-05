using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] personInfo = Console.ReadLine()
                .Split(new string[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);
                List<Person> people = new List<Person>();

                for (int i = 0; i < personInfo.Length; i += 2)
                {
                    string personName = personInfo[i];
                    int money = int.Parse(personInfo[i + 1]);
                    Person person = new Person(personName, money);
                    people.Add(person);
                }
                string[] productInfo = Console.ReadLine()
                    .Split(new string[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);
                List<Product> products = new List<Product>();

                for (int i = 0; i < productInfo.Length; i += 2)
                {
                    string productName = productInfo[i];
                    int productCost = int.Parse(productInfo[i + 1]);
                    Product product = new Product(productName, productCost);
                    products.Add(product);
                }
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] tokens = command.Split();
                    string name = tokens[0];
                    string product = tokens[1];
                    Person person = people.Find(x => x.Name == name);
                    Product currentProduct = products.Find(x => x.Name == product);

                    if (person.AddProduct(currentProduct) == true)
                    {
                        Console.WriteLine($"{person.Name} bought {currentProduct.Name}");
                        command = Console.ReadLine();
                        continue;
                    
                    }
                    command = Console.ReadLine();
                }
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Name} - {person.ReturnProducts()}");      
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }                      
        }
    }
}
