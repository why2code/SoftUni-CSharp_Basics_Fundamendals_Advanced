using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //09. Pokemon Trainer
            string commands = Console.ReadLine();
            List<Trainer> trainersList = new List<Trainer>();

            while (commands != "Tournament")
            {
                string[] commArgs = commands.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = commArgs[0];
                string pokemonName = commArgs[1];
                string pokemonElement = commArgs[2];
                int pokemonHealth = int.Parse(commArgs[3]);

                Pokemon currPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!trainersList.Any(x => x.Name == trainerName))
                {
                    List<Pokemon> pokemonList = new List<Pokemon>();
                    pokemonList.Add(currPokemon);
                    Trainer currTrainer = new Trainer(trainerName, pokemonList);
                    currTrainer.Pokemons = pokemonList;
                    trainersList.Add(currTrainer);

                }
                else
                {
                    //amend trainerlist by adding new pokemon to the existing trainer
                    var currPokemonsList = trainersList.First(x => x.Name == trainerName).Pokemons;
                    currPokemonsList.Add(currPokemon);
                    trainersList.First(x => x.Name == trainerName).Pokemons = currPokemonsList;
                }

                commands = Console.ReadLine();
            }

            string actionCommand = Console.ReadLine();
            while (actionCommand != "End")
            {
                if (actionCommand == "Fire")
                {
                    ValidateExistingPokemon(trainersList, actionCommand);
                }
                else if (actionCommand == "Water")
                {
                    ValidateExistingPokemon(trainersList, actionCommand);
                }
                else if (actionCommand == "Electricity")
                {
                    ValidateExistingPokemon(trainersList, actionCommand);
                }

                actionCommand = Console.ReadLine();
            }

            trainersList = trainersList.OrderByDescending(x => x.Badges).ToList();
            foreach (var trainer in trainersList)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }

            ////-----------------------------------------------------------------------------
            ////08. Car Salesman
            //int numOfEngines = int.Parse(Console.ReadLine());
            //List<Engine> engines = new List<Engine>();
            //for (int i = 0; i < numOfEngines; i++)
            //{
            //    //"{model} {power} {displacement} {efficiency}"
            //    string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string model = input[0];
            //    int power = int.Parse(input[1]);
            //    Engine currEngine = new Engine(model, power);
            //    if (input.Length == 4)
            //    {
            //        double displacement = double.Parse(input[2]);
            //        string efficiency = input[3];
            //        currEngine.Displacement = displacement;
            //        currEngine.Efficiency = efficiency;
            //    }
            //    else if (input.Length == 3)
            //    {
            //        string elementThree = input[2];
            //        double displacement = double.MinValue;
            //        if (double.TryParse(elementThree, out displacement))
            //        {
            //            displacement = double.Parse(elementThree);
            //            currEngine.Displacement = displacement;
            //        }
            //        else
            //        {
            //            string efficiency = elementThree;
            //            currEngine.Efficiency = efficiency;
            //        }
            //    }

            //    engines.Add(currEngine);
            //}

            //int numOfCars = int.Parse(Console.ReadLine());
            //List<Car> cars = new List<Car>();
            //for (int i = 0; i < numOfCars; i++)
            //{
            //    string[] inputForCars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string carModel = inputForCars[0];
            //    string engineName = inputForCars[1];
            //    Engine carEngine = engines.First(x => x.Model == engineName);

            //    Car currentCar = new Car(carModel, carEngine);

            //    if (inputForCars.Length == 4)
            //    {
            //        int carWeight = int.Parse(inputForCars[2]);
            //        string color = inputForCars[3];
            //        currentCar.Weight = carWeight;
            //        currentCar.Color = color;
            //    }
            //    else if (inputForCars.Length == 3)
            //    {
            //        string elementThree = inputForCars[2];
            //        int weight = int.MinValue;
            //        if (int.TryParse(elementThree, out weight))
            //        {
            //            weight = int.Parse(elementThree);
            //            currentCar.Weight = weight;
            //        }
            //        else
            //        {
            //            string color = elementThree;
            //            currentCar.Color = color;
            //        }
            //    }
            //    cars.Add(currentCar);
            //}

            //foreach (var car in cars)
            //{
            //    Console.WriteLine($"{car.Model}:");
            //    Console.WriteLine($"  {car.Engine.Model}:");
            //    Console.WriteLine($"    Power: {car.Engine.Power}");

            //    //optional prints for Engine -> displacement
            //    if (car.Engine.Displacement != double.MinValue)
            //    {
            //        Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"    Displacement: n/a");
            //    }

            //    //optional prints for Engine -> efficiency
            //    if (car.Engine.Efficiency != null)
            //    {
            //        Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"    Efficiency: n/a");
            //    }

            //    //optional prints for Car -> weight
            //    if (car.Weight != int.MinValue)
            //    {
            //        Console.WriteLine($"  Weight: {car.Weight}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"  Weight: n/a");
            //    }

            //    //optional prints for Car -> color
            //    if (car.Color != null)
            //    {
            //        Console.WriteLine($"  Color: {car.Color}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"  Color: n/a");
            //    }
            //}

            ////-----------------------------------------------------------------------------
            ////07. Raw Data
            //int num = int.Parse(Console.ReadLine());
            //List<CarRawData> cars = new List<CarRawData>();
            //for (int i = 0; i < num; i++)
            //{
            //    string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string model = commandArgs[0];
            //    double engineSpeed = double.Parse(commandArgs[1]);
            //    double enginePower = double.Parse(commandArgs[2]);
            //    double cargoWeight = double.Parse(commandArgs[3]);
            //    string cargoType = commandArgs[4];
            //    double tire1Pressure = double.Parse(commandArgs[5]);
            //    int tire1Age = int.Parse(commandArgs[6]);
            //    double tire2Pressure = double.Parse(commandArgs[7]);
            //    int tire2Age = int.Parse(commandArgs[8]);
            //    double tire3Pressure = double.Parse(commandArgs[9]);
            //    int tire3Age = int.Parse(commandArgs[10]);
            //    double tire4Pressure = double.Parse(commandArgs[11]);
            //    int tire4Age = int.Parse(commandArgs[12]);

            //    cars.Add(new CarRawData(model,engineSpeed,enginePower,cargoWeight,cargoType,tire1Pressure,tire1Age,tire2Pressure,tire2Age,
            //        tire3Pressure,tire3Age,tire4Pressure, tire4Age));
            //}

            //string lastCommand = Console.ReadLine();
            //if (lastCommand == "fragile")
            //{
            //    string requiredCargoType = "fragile";
            //    List<CarRawData> searchedCars = cars.FindAll(x => x.Cargo.Type == requiredCargoType);
            //    foreach (var car in searchedCars)
            //    {
            //        if (car.Tires.Any(x => x.Pressure < 1))
            //        {
            //            Console.WriteLine(car.Model);
            //        }
            //    }
            //}
            //else if (lastCommand == "flammable")
            //{
            //    string requiredCargoType = "flammable";
            //    List<CarRawData> searchedCars = cars.FindAll(x => x.Cargo.Type == requiredCargoType);
            //    foreach (var car in searchedCars)
            //    {
            //        if (car.Engine.Power > 250)
            //        {
            //            Console.WriteLine(car.Model);
            //        }
            //    }
            //}

            ////-----------------------------------------------------------------------------
            ////06. Speed Racing 
            //int num = int.Parse(Console.ReadLine());
            //List<CarSpeedRacing> cars = new List<CarSpeedRacing>();
            //for (int i = 0; i < num; i++)
            //{
            //    string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string model = carData[0];
            //    double fueltank = double.Parse(carData[1]);
            //    double consumption = double.Parse(carData[2]);

            //    CarSpeedRacing currCar = new CarSpeedRacing(model, fueltank, consumption);
            //    cars.Add(currCar);
            //}

            //string command = Console.ReadLine();
            //while (command != "End")
            //{
            //    string[] commArgs = command.Split();
            //    string driveModel = commArgs[1];
            //    double kilometers = double.Parse(commArgs[2]);

            //    CarSpeedRacing travellingCar = cars.First(x => x.Model == driveModel);
            //    travellingCar.Drive(kilometers);
            //    command = Console.ReadLine();
            //}

            //foreach (var car in cars)
            //{
            //    Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            //}

            ////-----------------------------------------------------------------------------
            ////04. Opinion poll
            //int num = int.Parse(Console.ReadLine());
            //List<Person> peopleOver30 = new List<Person>();
            //for (int i = 0; i < num; i++)
            //{
            //    string[] input = Console.ReadLine().Split();
            //    string name = input[0];
            //    int age = int.Parse(input[1]);

            //    if (age > 30)
            //    {
            //        peopleOver30.Add(new Person(name, age));
            //    }
            //}

            //peopleOver30 = peopleOver30.OrderBy(x => x.Name).ToList();
            //foreach (var person in peopleOver30)
            //{
            //    Console.WriteLine($"{person.Name} - {person.Age}");
            //}

            ////-----------------------------------------------------------------------------
            ////03. OldestFamilyMember
            //int num = int.Parse(Console.ReadLine());
            //Family familia = new Family();

            //for (int i = 0; i < num; i++)
            //{
            //    string[] input = Console.ReadLine().Split();
            //    string name = input[0];
            //    int age = int.Parse(input[1]);

            //    Person memberToAddIntoFamily = new Person(name, age);
            //    familia.AddMember(memberToAddIntoFamily);
            //}

            ////familia.GetOldestMember();
            //Person oldestPerson = familia.GetOldestMember();
            //Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

        }

        private static void ValidateExistingPokemon(List<Trainer> trainersList, string actionCommand)
        {
            foreach (Trainer trainer in trainersList)
            {
                if (trainer.Pokemons.Any(x => x.Element == actionCommand))
                {
                    trainer.Badges += 1;
                }
                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        Pokemon pokemon = trainer.Pokemons[i];
                        //just checking if 0 pokemons to avoid an exception
                        if (trainer.Pokemons.Count == 0)
                        {
                            continue;
                        }
                        else
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(pokemon);
                            }
                        }
                    }
                }
            }
        }
    }
}
