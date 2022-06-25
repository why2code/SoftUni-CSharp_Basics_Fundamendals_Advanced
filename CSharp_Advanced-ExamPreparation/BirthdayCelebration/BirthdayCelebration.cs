using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    internal class BirthdayCelebration
    {
        static void Main(string[] args)
        {
            Stack<int> guestsEatingCapacity = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray().Reverse());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int wastedFoodTotal = 0;
            bool guestsOver = false;

            while (plates.Count > 0)
            {
                if (guestsEatingCapacity.Count == 0)
                {
                    guestsOver = true;
                    break;
                }

                int currPlateValue = plates.Peek();
                int currGuestValue = guestsEatingCapacity.Peek();

                if (currGuestValue > currPlateValue)
                {
                    currGuestValue -= currPlateValue;
                    guestsEatingCapacity.Pop();
                    guestsEatingCapacity.Push(currGuestValue);
                    plates.Pop();
                }
                else
                {
                    int foodRemaining = currPlateValue - currGuestValue;
                    wastedFoodTotal += foodRemaining;
                    guestsEatingCapacity.Pop();
                    plates.Pop();
                }
            }

            if (guestsOver)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestsEatingCapacity)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFoodTotal}");
        }
    }
}
