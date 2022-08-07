using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class RacerRepository :IRepository<IRacer>
    {
        private readonly List<IRacer> models;
        public IReadOnlyCollection<IRacer> Models => this.models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }
        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            this.models.Add(model);
        }

        public bool Remove(IRacer model) => this.models.Remove(model);

        public IRacer FindBy(string property) => this.models.FirstOrDefault(r => r.Username == property);

    }
}
