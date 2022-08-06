using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;
        public IReadOnlyCollection<ICar> Models => this.models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            models.Add(model);
        }

        public bool Remove(ICar model) => models.Remove(model);
       

        public ICar FindBy(string property) => models.FirstOrDefault(c => c.VIN == property);
        
    }
}
