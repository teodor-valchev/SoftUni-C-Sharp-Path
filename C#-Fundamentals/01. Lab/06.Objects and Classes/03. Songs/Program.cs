using System;
using System.Collections.Generic;

namespace _03._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSong= int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>(numSong);

            for (int i = 0; i < numSong; i++)
            {
                string[] data = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
;            }

            string typeList = Console.ReadLine();

            switch (typeList)
            {
                case "all":
                    foreach (Song song in songs)
                    {
                        Console.WriteLine(song.Name);
                    }
                    break;
                default:
                    foreach (Song song in songs)
                    {
                        if (song.TypeList== typeList)
                        {
                            Console.WriteLine(song.Name);
                        }
                    }
                    break;
            }
        }
    }
}
