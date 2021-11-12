using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {


            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (input != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split();
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                if (input == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (input == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (input == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }
                else if (input == "Tomcat")
                {
                    Tomcat tomCat = new Tomcat(name, age, gender);
                    animals.Add(tomCat);
                }
                else if (input == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age, gender);
                    animals.Add(kitten);
                }
                else if (gender =="Tomcat")
                {
                    Tomcat tomCat = new Tomcat(name, age, gender);
                }
                else if (gender == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age, gender);
                  
                }


                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }

        }
    }
}
