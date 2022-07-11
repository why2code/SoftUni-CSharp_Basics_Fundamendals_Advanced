using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : ICitizen
    {
        public Robot(string model, string id)
        {
            this.model = model;
            this.id = id;
        }
        public string model { get; private set; }
        public string id {get; private set;}
    }
}
