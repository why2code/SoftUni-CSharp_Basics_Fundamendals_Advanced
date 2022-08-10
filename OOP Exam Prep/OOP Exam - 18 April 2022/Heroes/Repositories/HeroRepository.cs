using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models;
        public IReadOnlyCollection<IHero> Models => (IReadOnlyCollection<IHero>)this.models;

        public HeroRepository()
        {
            this.models = new List<IHero>();
        }


        public void Add(IHero model) => this.models.Add(model);

        public bool Remove(IHero model) => this.models.Remove(model);

        public IHero FindByName(string name) => this.models.FirstOrDefault(h => h.Name == name);

    }
}
