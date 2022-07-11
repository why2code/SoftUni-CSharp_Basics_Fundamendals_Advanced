using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface ICitizen
    {
        public string id { get; }

        public string birthdate { get; }
    }
}
