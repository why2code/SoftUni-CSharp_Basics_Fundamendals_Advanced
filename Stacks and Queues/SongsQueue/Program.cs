using System;
using System.Collections.Generic;

namespace SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
                else if (command.StartsWith("Add"))
                {
                    string newSongName = command.Substring(4);
                    if (songs.Contains(newSongName))
                    {
                        Console.WriteLine($"{newSongName} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(newSongName);
                    }
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
