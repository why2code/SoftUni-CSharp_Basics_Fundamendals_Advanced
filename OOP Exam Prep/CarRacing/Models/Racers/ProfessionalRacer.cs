using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        public static int DrivingExperienceStartingValueForProfessionalRacer = 30;
        public static string RacingBehaviourStartingValueForProfessionalRacer = "strict";
        public ProfessionalRacer(string username, ICar car) 
            : base(username, RacingBehaviourStartingValueForProfessionalRacer, DrivingExperienceStartingValueForProfessionalRacer, car)
        {
        }


        public override void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += 10;
        }
    }
}
