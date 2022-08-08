using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Pilot :IPilot
    {
        private string fullname;
        private bool canrace;
        private IFormulaOneCar car;
        private int numberOfWins;

        private Pilot()
        {
            this.CanRace = false;
        }
        public Pilot(string fullName)
                    : this()
        {
            this.FullName = fullName;
        }

        public string FullName
        {
            get => this.fullname;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                this.fullname = value;
            }
        }
        public IFormulaOneCar Car
        {
            get => this.car;
            private set
            {
                if (value is null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                this.car = value;
            }
        }
        public int NumberOfWins
        {
            get => this.numberOfWins;
            private set => this.numberOfWins = value;
        }
        public bool CanRace
        {
            get => this.canrace;
            private set => this.canrace = value;
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
