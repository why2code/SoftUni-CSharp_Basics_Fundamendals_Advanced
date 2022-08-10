using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private static int maceDamage = 25;
        public Mace(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            this.Durability--;
            return maceDamage;
        }
    }
}
