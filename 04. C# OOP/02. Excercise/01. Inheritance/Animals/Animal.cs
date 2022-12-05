using System;

namespace Animals
{
    public class Animal
    {
        private int age;


        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }


        public string Gender { get; set; }


        public virtual string ProduceSound()
        {
            return $"";
        }
    }
}