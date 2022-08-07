using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        public static int DrivingExperienceStartingValueForStreetRacer = 10;
        public static string RacingBehaviourStartingValueForStreetRacer = "aggressive";
        public StreetRacer(string username, ICar car) 
            : base(username, RacingBehaviourStartingValueForStreetRacer, DrivingExperienceStartingValueForStreetRacer, car)
        {
        }

        public override void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += 5;
        }
    }
}
