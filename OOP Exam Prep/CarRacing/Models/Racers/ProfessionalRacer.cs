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
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
