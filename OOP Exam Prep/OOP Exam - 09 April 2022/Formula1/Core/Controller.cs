using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = this.pilotRepository.FindByName(fullName);
            if (pilot != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = this.carRepository.FindByName(model);

            if (car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
                this.carRepository.Add(car);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
                this.carRepository.Add(car);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotName);

            if (pilot is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage,
                    pilotName));
            }

            IFormulaOneCar car = this.carRepository.FindByName(carModel);
            if (car is null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            if (pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage,
                    pilotName));
            }
            else
            {
                pilot.AddCar(car);
                this.carRepository.Remove(car);
                return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
            }

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race is null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);
            if (pilot is null || pilot.CanRace == false || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage,
                    pilotFullName));
            }
            else
            {
                race.Pilots.Add(pilot);
                return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
            }

        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race is null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            int pilotsCount = race.Pilots.Count;
            if (pilotsCount < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            
            var sortedPilots = race.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps));
            race.TookPlace = true;


            IPilot winner = sortedPilots.First();
            winner.WinRace();
            IPilot secondPlace = sortedPilots.Skip(1).First();
            IPilot thirdPlace = sortedPilots.Skip(2).First();

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, winner.FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, secondPlace.FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, thirdPlace.FullName, raceName));;

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();
            foreach (var race in this.raceRepository.Models)
            {
                if (race.TookPlace == true)
                {
                    sb.AppendLine(race.RaceInfo());
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();
            var sortedPilots = this.pilotRepository
                .Models.OrderByDescending(p => p.NumberOfWins);

            foreach (var pilot in sortedPilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
