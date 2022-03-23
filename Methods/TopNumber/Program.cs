using System;

namespace TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            isTopNumber(number);
        }

        static void isTopNumber(int number)
        {
            int sumOfDigits = 0;
            bool containsOddValue = false;
            for (int i = 17; i <= number; i++)
            {
                containsOddValue = false;
                sumOfDigits = 0;
                int tempNumb = i;
                while (tempNumb > 0)
                {
                    int lastDigit = tempNumb % 10;
                    tempNumb /= 10;

                    if (lastDigit % 2 != 0)
                    {
                        containsOddValue = true;
                    }

                    sumOfDigits += lastDigit;
                }

                if (sumOfDigits % 8 == 0 && containsOddValue == true)
                {
                    Console.WriteLine($"{i}");
                }

            }
        }
    }
}
