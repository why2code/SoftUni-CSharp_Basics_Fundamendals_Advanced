﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            //===============================================================================
            //8. Threeuple
            string firstInputForPerson = Console.ReadLine();
            string[] personDetails = firstInputForPerson.Split();
            string name = $"{personDetails[0]} {personDetails[1]}";
            string address = personDetails[2];
            int townIndex = name.Length + 1 + address.Length + 1; //To be used to capture town (single word or multiple words)
            string town = firstInputForPerson.Substring(townIndex);
            Threeuple<string, string, string> someonesAddress = new Threeuple<string, string, string>(name, address, town);

            string[] beerForPerson = Console.ReadLine().Split();
            string personsName = beerForPerson[0];
            int litersOfBeer = int.Parse(beerForPerson[1]);
            bool isDrung = beerForPerson[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> personDrunkOrNot = new Threeuple<string, int, bool>(personsName, litersOfBeer, isDrung);

            string[] numDetails = Console.ReadLine().Split();
            string bankersName = numDetails[0];
            double cashBalance = double.Parse(numDetails[1]);
            string bankName = numDetails[2];
            Threeuple<string, double, string> bankBalanceOfPerson = new Threeuple<string, double, string>(bankersName, cashBalance, bankName);

            Console.WriteLine(someonesAddress);
            Console.WriteLine(personDrunkOrNot);
            Console.WriteLine(bankBalanceOfPerson);

            ////===============================================================================
            ////7. Tuple
            //string[] personDetails = Console.ReadLine().Split();
            //string name = $"{personDetails[0]} {personDetails[1]}";
            //string city = personDetails[2];
            //Tuple<string, string> person = new Tuple<string, string>(name, city);

            //string[] beerForPerson = Console.ReadLine().Split();
            //string personsName = beerForPerson[0];
            //int litersOfBeer = int.Parse(beerForPerson[1]);
            //Tuple<string, int> beerDetails = new Tuple<string, int>(personsName, litersOfBeer);

            //string[] numDetails = Console.ReadLine().Split();
            //int firstNumber = int.Parse(numDetails[0]);
            //double secondNumber = double.Parse(numDetails[1]);
            //Tuple<int, double> numbers = new Tuple<int, double>(firstNumber, secondNumber);

            //Console.WriteLine(person);
            //Console.WriteLine(beerDetails);
            //Console.WriteLine(numbers);

            ////===============================================================================
            ////6. Generic Count Method String  
            //int n = int.Parse(Console.ReadLine());
            //var elements = new List<double>();
            //for (int i = 0; i < n; i++)
            //{
            //    double currElement = double.Parse(Console.ReadLine());
            //    elements.Add(currElement);
            //}

            //double comparer = double.Parse(Console.ReadLine());
            //Console.WriteLine(CountOfGreaterThan<double>(elements, comparer));

            ////===============================================================================
            ////5. Generic Count Method String  
            //int n = int.Parse(Console.ReadLine());
            //var elements = new List<string>();
            //for (int i = 0; i < n; i++)
            //{
            //    string currElement = Console.ReadLine();
            //    elements.Add(currElement);
            //}

            //string comparer = Console.ReadLine();
            //Console.WriteLine(CountOfGreaterThan<string>(elements, comparer));


            ////===============================================================================
            ////4. Generic Swap Method Integer 
            //int n = int.Parse(Console.ReadLine());
            //var allBoxes = new List<Box<int>>();
            //for (int i = 0; i < n; i++)
            //{
            //    var box = new Box<int>(int.Parse(Console.ReadLine()));
            //    allBoxes.Add(box);

            //}

            //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int index1 = indexes[0];
            //int index2 = indexes[1];
            //var swappedBoxes = SwapIndexes(allBoxes, index1, index2);

            //foreach (var box in swappedBoxes)
            //{
            //    Console.WriteLine(box.ToString());
            //}


            ////===============================================================================
            ////3. Generic Swap Method String 
            //int n = int.Parse(Console.ReadLine());
            //var allBoxes = new List<Box<string>>();
            //for (int i = 0; i < n; i++)
            //{
            //    var box = new Box<string>(Console.ReadLine());
            //    allBoxes.Add(box);

            //}

            //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int index1 = indexes[0];
            //int index2 = indexes[1];
            //var swappedBoxes = SwapIndexes(allBoxes, index1, index2);

            //foreach (var box in swappedBoxes)
            //{
            //    Console.WriteLine(box.ToString());
            //}

            ////===============================================================================
            ////2. Generic Box of Integers
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine();
            //    var box = new Box<int>(int.Parse(input));
            //    Console.WriteLine(box.ToString());
            //}

            ////===============================================================================
            ////1. Generic Box of String
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine();
            //    var box = new Box<string>(input);
            //    Console.WriteLine(box.ToString());
            //}
        }

        public static List<Box<T>> SwapIndexes<T>(List<Box<T>> boxes, int index1, int index2)
        {
            if ((index1 < 0 && index1 >= boxes.Count)
               || (index2 < 0 && index2 >= boxes.Count))
            {
                throw new ArgumentException("Invalid indexes outside of the boundrays of the List.");
            }

            var swapValue = boxes[index1];
            boxes[index1] = boxes[index2];
            boxes[index2] = swapValue;
            return boxes;
        }

        public static int CountOfGreaterThan<T>(List<T> list, T toCompare)
        where T : IComparable<T>
        {
            return list.Count(x => x.CompareTo(toCompare) > 0);
        }
    }
}
