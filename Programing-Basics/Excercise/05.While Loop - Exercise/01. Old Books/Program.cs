using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string serchedBook = Console.ReadLine();
            int bookCounter = 0;
            bool isFound = false;

            while (isFound==false)
            {
                string newBook = Console.ReadLine();
                bookCounter++;
                if (newBook=="No More Books")
                {
                    break;
                }
                if (newBook==serchedBook)
                {
                    isFound = true;
                }

            }
            if (isFound)
            {
                Console.WriteLine($"You checked { bookCounter-1} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {bookCounter-1} books and found it.");
            }
           

        }
    }
}
