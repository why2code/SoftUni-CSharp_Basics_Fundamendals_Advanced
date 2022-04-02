using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int herosCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            for (int i = 0; i < herosCount; i++)
            {
                string[] currentHerp = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string heroName = currentHerp[0];
                int hp = int.Parse(currentHerp[1]);
                int mana = int.Parse(currentHerp[2]);

                heroes.Add(heroName, new List<int> { hp, mana });
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commArgs = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string typeOfCommand = commArgs[0];

                if (typeOfCommand == "CastSpell")
                {
                    string heroName = commArgs[1];
                    int mpRequired = int.Parse(commArgs[2]);
                    string spellName = commArgs[3];
                    CastSpell(heroes, heroName, mpRequired, spellName);
                }
                else if (typeOfCommand == "TakeDamage")
                {
                    string heroName = commArgs[1];
                    int damage = int.Parse(commArgs[2]);
                    string attacker = commArgs[3];
                    TakeDamage(heroes, heroName, damage, attacker);
                }
                else if (typeOfCommand == "Recharge")
                {
                    string heroName = commArgs[1];
                    int manaToRecharge = int.Parse(commArgs[2]);
                    RechargeMana(heroes, heroName, manaToRecharge);
                }
                else if (typeOfCommand == "Heal")
                {
                    string heroName = commArgs[1];
                    int healthToRecharge = int.Parse(commArgs[2]);
                    RechargeHP(heroes, heroName, healthToRecharge);
                }

                command = Console.ReadLine();
            }

            foreach (var hero in heroes)
            {
                string nameOfHero = hero.Key;
                int[] heroData = hero.Value.ToArray();
                Console.WriteLine(nameOfHero);
                Console.WriteLine($"  HP: {heroData[0]}");
                Console.WriteLine($"  MP: {heroData[1]}");
            }

        }

        static void CastSpell(Dictionary<string, List<int>> heroes, string heroName, int manaRequired, string spellName)
        {
            if (heroes.ContainsKey(heroName))
            {
                //int[] heroData = heroes[heroName].ToArray();
                List<int> currentHeroData = heroes[heroName];
                int currentHeroHP = currentHeroData[0];
                int currentHeroMana = currentHeroData[1];

                if (currentHeroMana >= manaRequired)
                {
                    currentHeroMana -= manaRequired;
                    heroes[heroName] = new List<int> { currentHeroHP, currentHeroMana };
                    Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currentHeroMana} MP!");
                }
                else
                {
                    Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                }

            }

        }


        static void TakeDamage(Dictionary<string, List<int>> heroes, string heroName, int damageTaken, string attacker)
        {
            if (heroes.ContainsKey(heroName))
            {
                List<int> currentHeroData = heroes[heroName];
                int currentHeroHP = currentHeroData[0];
                int currentHeroMana = currentHeroData[1];

                if (currentHeroHP > damageTaken)
                {
                    currentHeroHP -= damageTaken;
                    heroes[heroName] = new List<int> { currentHeroHP, currentHeroMana };
                    Console.WriteLine($"{heroName} was hit for {damageTaken} HP by {attacker} and now has {currentHeroHP} HP left!");
                }
                else
                {
                    Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    heroes.Remove(heroName);
                }

            }

        }


        static void RechargeMana(Dictionary<string, List<int>> heroes, string heroName, int manaToRecharge)
        {
            if (heroes.ContainsKey(heroName))
            {
                List<int> currentHeroData = heroes[heroName];
                int currentHeroHP = currentHeroData[0];
                int currentHeroMana = currentHeroData[1];
                int tempMana = currentHeroMana;

                currentHeroMana += manaToRecharge;
                if (currentHeroMana > 200)
                {
                    currentHeroMana = 200;
                    Console.WriteLine($"{heroName} recharged for {200 - tempMana} MP!");

                }
                else
                {
                    Console.WriteLine($"{heroName} recharged for {manaToRecharge} MP!");
                }

                heroes[heroName] = new List<int> { currentHeroHP, currentHeroMana };

            }

        }


        static void RechargeHP(Dictionary<string, List<int>> heroes, string heroName, int healthToRecharge)
        {
            if (heroes.ContainsKey(heroName))
            {
                List<int> currentHeroData = heroes[heroName];
                int currentHeroHP = currentHeroData[0];
                int tempHP = currentHeroHP;
                int currentHeroMana = currentHeroData[1];

                currentHeroHP += healthToRecharge;
                if (currentHeroHP > 100)
                {
                    currentHeroHP = 100;
                    Console.WriteLine($"{heroName} healed for {100 - tempHP} HP!");
                }
                else
                {
                    Console.WriteLine($"{heroName} healed for {healthToRecharge} HP!");
                }

                heroes[heroName] = new List<int> { currentHeroHP, currentHeroMana };

            }

        }



    }
}
