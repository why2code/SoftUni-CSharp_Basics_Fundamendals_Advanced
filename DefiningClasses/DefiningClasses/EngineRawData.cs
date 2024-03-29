﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class EngineRawData
    {
        private double speed;
        private double power;

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public double Power
        {
            get { return power; }
            set { power = value; }
        }

        public EngineRawData(double speed, double power)
        {
            Speed = speed;
            Power = power;
        }
    }
}
