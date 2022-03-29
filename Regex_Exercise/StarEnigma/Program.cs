using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> messagesToDecrypt = new List<string>();
            int decryptionCounter = 0;
            int planetsAttackedCounter = 0;
            int planetsDestroyedCounter = 0;
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int messagesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < messagesCount; i++)
            {
                string message = Console.ReadLine();
                messagesToDecrypt.Add(message);
            }

            for (int j = 0; j < messagesToDecrypt.Count; j++)
            {
                string currentDecryptedMessage = messagesToDecrypt[j];
                foreach (char letter in currentDecryptedMessage)
                {
                    if (letter == 's'
                        || letter == 'S'
                        || letter == 't'
                        || letter == 'T'
                        || letter == 'a'
                        || letter == 'A'
                        || letter == 'r'
                        || letter == 'R')
                    {
                        decryptionCounter++;
                    }
                }

                List<char> tempMessageForDecrypting = new List<char>();
                foreach (char letter in currentDecryptedMessage)
                {
                    tempMessageForDecrypting.Add((char)(letter - decryptionCounter));
                }

                string decrypted = string.Join("", tempMessageForDecrypting);
                messagesToDecrypt.Insert(0, decrypted);
                messagesToDecrypt.Remove(messagesToDecrypt[j + 1]);
                decryptionCounter = 0;

            }

            //Returning messages in original order received
            messagesToDecrypt.Reverse();

            //Searching for matches and adding to attached/destroyed planets list of names and counters
            string pattern = @"[\@]{1}(?<planet>[A-Za-z]+)[^@\-!:>]*?\:(?<population>\d+)[^@\-!:>]*?\!(?<type>A|D)\![^@\-!:>]*?[\-]{1}[\>]{1}(?<soldiers>\d+)";
            foreach (string message in messagesToDecrypt)
            {
                Match match = Regex.Match(message, pattern);
                if (match.Success)
                {
                    string attackType = match.Groups["type"].Value;
                    string planetName = match.Groups["planet"].Value;
                    if (attackType == "A")
                    {
                        planetsAttackedCounter++;
                        attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        planetsDestroyedCounter++;
                        destroyedPlanets.Add(planetName);
                    }

                }

            }

            Console.WriteLine($"Attacked planets: {planetsAttackedCounter}");
            if (planetsAttackedCounter > 0)
            {
                attackedPlanets.Sort();
                foreach (var item in attackedPlanets)
                {
                    Console.WriteLine($"-> {item}");
                }
            }
            Console.WriteLine($"Destroyed planets: {planetsDestroyedCounter}");
            if (planetsDestroyedCounter > 0)
            {
                destroyedPlanets.Sort();
                foreach (var item in destroyedPlanets)
                {
                    Console.WriteLine($"-> {item}");
                }
            }
        }
    }
}
