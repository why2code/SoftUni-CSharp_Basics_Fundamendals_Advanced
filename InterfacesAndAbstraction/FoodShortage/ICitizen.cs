using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface ICitizen
    {
        public string id { get; }

        public string name { get; }
        public string birthdate { get; }
    }
}
