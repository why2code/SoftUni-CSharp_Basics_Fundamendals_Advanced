using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        List<Car> Participants;

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;


        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

       
        public void Add(Car car)
        {
            string licenceNumber = car.LicensePlate;
            if (Participants.Count < this.Capacity)
            {
                if (!Participants.Exists(x => x.LicensePlate == licenceNumber))
                {
                    if (car.HorsePower <= this.MaxHorsePower)
                    {
                        Participants.Add(car);
                    }
                }
            }
        }

        public bool Remove(string licensePlate)
        {
            if (Participants.Exists(x => x.LicensePlate == licensePlate))
            {
                Car currCar = Participants.Find(x => x.LicensePlate == licensePlate);
                Participants.Remove(currCar);
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            if (Participants.Exists(x => x.LicensePlate == licensePlate))
                return Participants.Find(x => x.LicensePlate == licensePlate);
            return null;
        }

        public Car GetMostPowerfulCar()
        {
            Car searchedCar = null;
            if (Participants.Count == 0)
            {
                return null;
            }
            int maxHorsepower = int.MinValue;
            foreach (var car in Participants)
            {
                int currentHorsepower = car.HorsePower;
                if (currentHorsepower > maxHorsepower)
                {
                    maxHorsepower = currentHorsepower;
                    searchedCar = car;
                }
            }
            return searchedCar;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(string.Join("", car));
            }
            return sb.ToString().TrimEnd();
        }
      
      
    }
}
