using System;

namespace Objects_and_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("ivan","petrov");
            //student1.FirstName = "Ivan";
            //student1.LastName = "Petrov";
            student1.Learning();
            Console.WriteLine($"Hallo my name is {student1.FirstName} {student1.LastName}");




        }

        public class Student
        {
            public Student(string firstName,string lastName) //това е конструктор
            {
                FirstName = firstName;
                LastName = lastName;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public void Learning()
            {
                Console.WriteLine("im learning");
            }
        }
    }
}
