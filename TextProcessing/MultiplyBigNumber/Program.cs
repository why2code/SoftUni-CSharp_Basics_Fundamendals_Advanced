using System;
using System.Collections.Generic;

namespace MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] numOne = Console.ReadLine().ToCharArray();
            int multiplier = int.Parse(Console.ReadLine());

            List<int> finalNumber = new List<int>();
            int passingOnDigit = 0;

            for (int i = numOne.Length - 1; i >= 0; i--)
            {
                // getting last index to start multipying
                int currNumb = numOne[i] - 48;

                int digitToAddToResult = ((currNumb * multiplier) % 10) + passingOnDigit;
                if (digitToAddToResult >= 10)
                {
                    digitToAddToResult -= 10;
                    finalNumber.Insert(0, digitToAddToResult);
                    passingOnDigit = ((currNumb * multiplier) / 10) + 1;
                }
                else
                {
                    finalNumber.Insert(0, digitToAddToResult);
                    passingOnDigit = ((currNumb * multiplier) / 10);
                }


                if (i == 0 && passingOnDigit != 0)
                {
                    finalNumber.Insert(0, passingOnDigit);
                }

            }

            if (finalNumber[0] == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(string.Join("", finalNumber));
            }
        }
    }
}
