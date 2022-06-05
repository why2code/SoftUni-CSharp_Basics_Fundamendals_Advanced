using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;

        private int badges;

        private List<Pokemon> pokemons;

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

       
        public Trainer(string name, List<Pokemon> pokemons)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }
    }
}
