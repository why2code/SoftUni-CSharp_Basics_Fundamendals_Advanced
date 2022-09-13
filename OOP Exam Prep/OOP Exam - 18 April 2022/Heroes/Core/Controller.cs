using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }


        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = this.heroes.FindByName(name);
            if (hero != null)
                throw new InvalidOperationException($"The hero {name} already exists.");


            if (type != "Knight" && type != "Barbarian")
                throw new InvalidOperationException("Invalid hero type.");


            //Hero not existing and type already validated.
            //Now we create the Hero and add to the heroes repository.
            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
                this.heroes.Add(hero);
                return $"Successfully added Sir {name} to the collection.";
            }
            else //(type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
                this.heroes.Add(hero);
                return $"Successfully added Barbarian {name} to the collection.";
            }

        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = this.weapons.FindByName(name);
            if (weapon != null)
                throw new InvalidOperationException($"The weapon {name} already exists.");

            if (type != "Claymore" && type != "Mace")
                throw new InvalidOperationException("Invalid weapon type.");

            //Weapon not existing and type validated.
            //We can now create the weapon and add it to the repository.
            if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
                this.weapons.Add(weapon);
            }
            else //type == "Mace"
            {
                weapon = new Mace(name, durability);
                this.weapons.Add(weapon);
            }

            string weaponType = weapon.GetType().Name.ToLower();
            return $"A {weaponType} {name} is added to the collection.";

        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.FindByName(heroName);
            if (hero is null)
                throw new InvalidOperationException($"Hero {heroName} does not exist.");

            IWeapon weapon = this.weapons.FindByName(weaponName);
            if (weapon is null)
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");

            if (hero.Weapon != null)
                throw new InvalidOperationException($"Hero {hero.Name} is well-armed.");

            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);
            string weaponType = weapon.GetType().Name.ToLower();
            return $"Hero {hero.Name} can participate in battle using a {weaponType}.";
        }

        public string StartBattle()
        {
            IMap map = new Map();
            return map.Fight(this.heroes.Models.ToList());
        }

        public string HeroReport()
        {
            var sb = new StringBuilder();
            var sortedHeroes = this.heroes.Models.OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health).ThenBy(h => h.Name);
           
            foreach (var hero in sortedHeroes)
            {
                string heroType = hero.GetType().Name;
                string heroWeaponArmedOrUnarmed = hero.Weapon == null ? "Unarmed" : hero.Weapon.Name;

                sb.AppendLine($"{heroType}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.AppendLine($"--Weapon: {heroWeaponArmedOrUnarmed}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
