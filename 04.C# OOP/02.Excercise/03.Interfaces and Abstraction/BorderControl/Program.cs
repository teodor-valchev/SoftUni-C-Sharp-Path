using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<IPerson> people = new List<IPerson>();
            List<IRobot> robots = new List<IRobot>();

            while (command != "End")
            {
                string[] tokens = command.Split();

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    IPerson citizen = new Citizen(name, age, id);
                    people.Add(citizen);
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    IRobot robot = new Robot(model, id);
                    robots.Add(robot);
                }
                command = Console.ReadLine();
            }
            string fakeId = Console.ReadLine();
            var fakePeople = people.FindAll(x => x.Id.EndsWith(fakeId));
            var fakeRobots = robots.FindAll(x => x.Id.EndsWith(fakeId));
            foreach (var fakeRobot in fakeRobots)
            {
                Console.WriteLine(fakeRobot.Id);
            }

            foreach (var person in fakePeople)
            {
                Console.WriteLine(person.Id);
            }
        }
    }
}

