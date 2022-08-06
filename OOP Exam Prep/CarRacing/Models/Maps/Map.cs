﻿using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;




namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() == true && racerTwo.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == true)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else
            {
                string racerOneDrivingBehaviour = racerOne.RacingBehavior;
                string racerTwoDrivingBehaviour = racerTwo.RacingBehavior;

                double racerOneracingBehaviorMultiplier = racerOneDrivingBehaviour == "strict" ? 1.2 : 1.1;
                double racerTworacingBehaviorMultiplier = racerTwoDrivingBehaviour == "strict" ? 1.2 : 1.1;

                double racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneracingBehaviorMultiplier;
                double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTworacingBehaviorMultiplier;

                if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username,
                        racerOne.Username);
                }
                else
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username,
                        racerTwo.Username);
                }
            }

        }
    }

}
