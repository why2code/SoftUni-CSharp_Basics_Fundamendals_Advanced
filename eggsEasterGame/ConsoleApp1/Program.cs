using System;

namespace eggsEasterGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of eggs hidden!");
            Console.WriteLine("=======================================");
            int eggs = int.Parse(Console.ReadLine());
            Console.WriteLine($"The game will now start, with {eggs} eggs total!");
            Console.WriteLine("=======================================");
            Console.WriteLine("Please enter the name of the kid who found an egg, and how many eggs were found:");

            int kociEggs = 0;
            int sofiEggs = 0;
            int ilkoEggs = 0;
            int totalEggsFound = 0;
            string winner = null;
            int winnersEggs = 0;

            while (totalEggsFound < eggs)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string kidName = input[0].ToLower();
                int eggsToAdd = int.Parse(input[1]);

                // sofi 5
                if (kidName == "sofi")
                {
                    if ((eggs - totalEggsFound) < eggsToAdd)
                    {
                        eggsToAdd = (eggs - totalEggsFound);
                        Console.WriteLine($"{kidName} can not find more eggs than what is left hidden!");
                        Console.WriteLine($"The number of eggs added to {kidName} will be {eggs - totalEggsFound}");
                    }
                    sofiEggs += eggsToAdd;
                    totalEggsFound += eggsToAdd;
                    Console.WriteLine($"{kidName.ToUpper()} just found {eggsToAdd} egg!");
                    Console.WriteLine($"{kidName} has {sofiEggs} total eggs so far.");
                    Console.WriteLine($"{eggs - totalEggsFound} eggs still remain hidden!");
                }
                else if (kidName == "ilko")
                {
                    if ((eggs - totalEggsFound) < eggsToAdd)
                    {
                        eggsToAdd = (eggs - totalEggsFound);
                        Console.WriteLine($"{kidName} can not find more eggs than what is left hidden!");
                        Console.WriteLine($"The number of eggs added to {kidName} will be {eggs - totalEggsFound}");
                    }
                    ilkoEggs += eggsToAdd;
                    totalEggsFound += eggsToAdd;
                    Console.WriteLine($"{kidName.ToUpper()} just found {eggsToAdd} egg!");
                    Console.WriteLine($"{kidName} has {ilkoEggs} total eggs so far.");
                    Console.WriteLine($"{eggs - totalEggsFound} eggs still remain hidden!");
                }
                else if (kidName == "koci")
                {
                    if ((eggs - totalEggsFound) < eggsToAdd)
                    {
                        eggsToAdd = (eggs - totalEggsFound);
                        Console.WriteLine($"{kidName} can not find more eggs than what is left hidden!");
                        Console.WriteLine($"The number of eggs added to {kidName} will be {eggs - totalEggsFound}");
                    }
                    kociEggs += eggsToAdd;
                    totalEggsFound += eggsToAdd;
                    Console.WriteLine($"{kidName.ToUpper()} just found {eggsToAdd} egg!");
                    Console.WriteLine($"{kidName} has {kociEggs} total eggs so far.");
                    Console.WriteLine($"{eggs - totalEggsFound} eggs still remain hidden!");
                }
                else
                {
                    Console.WriteLine("No such kid is playing in this game!");
                }



            }

            // Checking who is the winner
            bool winnerAvailable = false;
            if (ilkoEggs > kociEggs && ilkoEggs > sofiEggs)
            {
                winner = "Ilko";
                winnersEggs = ilkoEggs;
                winnerAvailable = true;
            }
            else if (kociEggs > ilkoEggs && kociEggs > sofiEggs)
            {
                winner = "Koci";
                winnersEggs = kociEggs;
                winnerAvailable = true;

            }
            else if (sofiEggs > ilkoEggs && sofiEggs > kociEggs)
            {
                winner = "Sofi";
                winnersEggs = sofiEggs;
            }
            else if ((ilkoEggs == kociEggs) && (sofiEggs == ilkoEggs) && (sofiEggs == kociEggs))
            {
                Console.WriteLine("Everyone has the same number of eggs!");
                Console.WriteLine($"Everyone wins and has {eggs / 3} eggs each!");
            }
            else if (ilkoEggs == kociEggs)
            {
                Console.WriteLine($"Ilko and Koci have the same number of eggs, and both are winners with {(eggs - sofiEggs) / 2} eggs each!");

            }
            else if (ilkoEggs == sofiEggs)
            {
                Console.WriteLine($"Ilko and Sofi have the same number of eggs, and both are winners with {(eggs - kociEggs) / 2} eggs each!");

            }
            else if (sofiEggs == kociEggs)
            {
                Console.WriteLine($"Sofi and Koci have the same number of eggs, and both are winners with {(eggs - ilkoEggs) / 2} eggs each!");

            }


            if (winnerAvailable)
            {
                Console.WriteLine($"The winner is: {winner}");
                Console.WriteLine($"{winner} has found {winnersEggs} eggs!");
            }
        }
    }
}
