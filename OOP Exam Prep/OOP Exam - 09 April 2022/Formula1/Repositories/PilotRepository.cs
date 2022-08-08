using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> models;
        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)this.models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }

        public void Add(IPilot model) => this.models.Add(model);

        public bool Remove(IPilot model) => this.models.Remove(model);

        public IPilot FindByName(string name) => this.models.FirstOrDefault(p => p.FullName == name);

    }
}
