using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        { 
           var input = Console.ReadLine().Split(@"\");

            var lastFile = input[input.Length - 1];
            var array = lastFile.Split(".");

            var name = array[0];
            var extention = array[1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extention}");

        }
    }
}
