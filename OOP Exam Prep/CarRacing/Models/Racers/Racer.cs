﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehaviour;
        private int drivingExperience;
        private ICar car;
        //protected int modifierDrivingExperience;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
            //this.modifierDrivingExperience = 0;
        }
        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                this.username = value;
            }
        }
        public string RacingBehavior
        {
            get => this.racingBehaviour;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                this.racingBehaviour = value;
            }

        }
        public int DrivingExperience
        {
            get => this.drivingExperience;
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                this.drivingExperience = value;
            }
        }
        public ICar Car
        {
            get => this.car;
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                this.car = value;
            }

        }

        public virtual void Race()
        {
            this.Car.Drive();
        }

    public bool IsAvailable() => this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace; //correct logic?

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"{this.GetType().Name}: {this.Username}");
            text.AppendLine($"--Driving behavior: {this.RacingBehavior}");
            text.AppendLine($"--Driving experience: {this.DrivingExperience}");
            text.AppendLine($"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})");
            return text.ToString().TrimEnd();
        }

    }
}
