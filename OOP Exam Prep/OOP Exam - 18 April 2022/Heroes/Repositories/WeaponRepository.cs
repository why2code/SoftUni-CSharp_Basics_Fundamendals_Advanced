using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;
        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)this.models;
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }


        public void Add(IWeapon model) => this.models.Add(model);
        public bool Remove(IWeapon model) => this.models.Remove(model);
        public IWeapon FindByName(string name) => this.models.FirstOrDefault(w => w.Name == name);
    }
}
