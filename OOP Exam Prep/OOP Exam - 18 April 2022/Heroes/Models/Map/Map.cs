using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knightsList = players.Where(p => p.GetType().Name == "Knight").ToList();
            List<IHero> barbariansList = players.Where(p => p.GetType().Name == "Barbarian").ToList();

            int knightCasulties = 0;
            int barbarianCasulties = 0;

            while (knightsList.Count > 0 && barbariansList.Count > 0)
            {
                //Knights attach first!
                foreach (var knight in knightsList)
                {
                    foreach (var barbarian in barbariansList)
                    {
                        if (knight.IsAlive && barbarian.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                            if (barbarian.IsAlive == false)
                            {
                                barbarianCasulties++;
                                barbariansList.Remove(barbarian);
                            }
                        }
                    }
                }

                //Barbarians turn to attack!
                foreach (var barbarian in barbariansList)
                {
                    foreach (var knight in knightsList)
                    {
                        if (knight.IsAlive && barbarian.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                            if (knight.IsAlive == false)
                            {
                                knightCasulties++;
                                knightsList.Remove(knight);
                            }
                        }
                    }
                }


            }

            //Determining which group won the battle
            if (knightsList.Count > 0)
            {
                return $"The knights took {knightCasulties} casualties but won the battle.";
            }
            return $"The barbarians took {barbarianCasulties} casualties but won the battle.";

        }
    }
}
