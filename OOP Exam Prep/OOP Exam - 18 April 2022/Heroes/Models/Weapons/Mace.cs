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
            if (this.Durability - 1 < 0)
            {
                this.Durability = 0;
            }
            else
            {
                this.Durability--;
            }
            return maceDamage;
        }
    }
}
