using System;

namespace eggsEasterGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggs = 12;

            int kociEggs = 0;
            int sofiEggs = 0;
            int ilkoEggs = 0;
            int totalEggsFound = 0;
            string winner = null;
            int winnersEggs = 0;

            while (totalEggsFound < 12)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string kidName = input[0].ToLower();
                int eggsToAdd = int.Parse(input[1]);

                // sofi 5
                if (kidName == "sofi")
                {
                    sofiEggs += eggsToAdd;
                    totalEggsFound += eggsToAdd;
                    Console.WriteLine($"{kidName.ToUpper()} just found {eggsToAdd} eggs!");
                }
                else if (kidName == "ilko")
                {
                    ilkoEggs += eggsToAdd;
                    totalEggsFound += eggsToAdd;
                    Console.WriteLine($"{kidName.ToUpper()} just found {eggsToAdd} eggs!");
                }
                else if (kidName == "koci")
                {
                    kociEggs += eggsToAdd;
                    totalEggsFound += eggsToAdd;
                    Console.WriteLine($"{kidName.ToUpper()} just found {eggsToAdd} eggs!");
                }
                else
                {
                    Console.WriteLine("No such kid is playing in this game!");
                }



            }

            if (ilkoEggs > kociEggs && ilkoEggs > sofiEggs)
            {
                winner = "Ilko";
                winnersEggs = ilkoEggs;
            }
            if (kociEggs > ilkoEggs && kociEggs > sofiEggs)
            {
                winner = "Koci";
                winnersEggs = kociEggs;
            }
            if (sofiEggs > ilkoEggs && sofiEggs > kociEggs)
            {
                winner = "Sofi";
                winnersEggs = sofiEggs;
            }

            Console.WriteLine($"The winner is: {winner}");
            Console.WriteLine($"{winner} has found {winnersEggs} eggs!");
        }
    }
}
