using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository :IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;
        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)this.models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

            
        public void Add(IFormulaOneCar model) => this.models.Add(model);

        public bool Remove(IFormulaOneCar model) => this.models.Remove(model);

        public IFormulaOneCar FindByName(string name) => this.models.FirstOrDefault(c => c.Model == name);

    }
}
