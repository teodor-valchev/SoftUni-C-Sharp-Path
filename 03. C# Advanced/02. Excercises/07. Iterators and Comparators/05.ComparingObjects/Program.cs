using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string commands = Console.ReadLine();
            List<Person> collection = new List<Person>();

            while (commands != "END")
            {
                var tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];
                Person person = new Person(name, age, town);
                collection.Add(person);
                commands = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            var equal = 0;
            var notEqual = 0;

            foreach (var person in collection)
            {
                if (collection[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }
            if (equal<=1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notEqual} {collection.Count}");
            }
        }
    }
}
