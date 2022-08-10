using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private static int claymoreDamage = 20;

        public Claymore(string name, int durability) 
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
            return claymoreDamage;
        }
    }
}
