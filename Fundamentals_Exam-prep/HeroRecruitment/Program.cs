using System;
using System.Collections.Generic;

namespace HeroRecruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroesCollection = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string typeOfCommand = commArgs[0];

                if (typeOfCommand == "Enroll")
                {
                    string heroName = commArgs[1];
                    EnrollHero(heroesCollection, heroName);
                }
                else if (typeOfCommand == "Learn")
                {
                    string heroName = commArgs[1];
                    string spell = commArgs[2];
                    LearnSpells(heroesCollection, heroName, spell);
                }
                else if (typeOfCommand == "Unlearn")
                {
                    string heroName = commArgs[1];
                    string spell = commArgs[2];
                    UnlearnSpells(heroesCollection, heroName, spell);
                }

                command = Console.ReadLine();
            }

            //Final printout
            Console.WriteLine("Heroes:");
            foreach (var hero in heroesCollection)
            {
                Console.Write($"== {hero.Key}:");
                if (hero.Value.Count > 0)
                {
                    int counter = hero.Value.Count;
                    foreach (var spell in hero.Value)
                    {
                        if (counter == 1)
                        {
                            Console.Write($" {spell}");
                        }
                        else
                        {
                            Console.Write($" {spell},");
                            counter--;
                        }

                    }

                }
                Console.WriteLine();


            }
        }

        static void EnrollHero(Dictionary<string, List<string>> heroesCollection, string heroName)
        {
            if (!heroesCollection.ContainsKey(heroName))
            {
                heroesCollection.Add(heroName, new List<string>());
            }
            else
            {
                Console.WriteLine($"{heroName} is already enrolled.");
            }
        }

        static void LearnSpells(Dictionary<string, List<string>> heroesCollection, string heroName, string spell)
        {
            if (!heroesCollection.ContainsKey(heroName))
            {
                Console.WriteLine($"{heroName} doesn't exist.");
            }
            else
            {
                if (heroesCollection[heroName].Contains(spell))
                {
                    Console.WriteLine($"{heroName} has already learnt {spell}.");
                }
                else
                {
                    heroesCollection[heroName].Add(spell);

                }
            }
        }


        static void UnlearnSpells(Dictionary<string, List<string>> heroesCollection, string heroName, string spell)
        {
            if (!heroesCollection.ContainsKey(heroName))
            {
                Console.WriteLine($"{heroName} doesn't exist.");
            }
            else
            {
                if (!heroesCollection[heroName].Contains(spell))
                {
                    Console.WriteLine($"{heroName} doesn't know {spell}.");
                }
                else
                {
                    heroesCollection[heroName].Remove(spell);
                }
            }
        }

    }
}
