using System;

namespace SmallestOfTheeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestNumber(numOne, numTwo, numThree));
        }

        static int SmallestNumber(int a, int b, int c)
        {
            int[] numbers = new int[3];
            numbers[0] = a;
            numbers[1] = b;
            numbers[2] = c;
            int minNumber = int.MaxValue;

            foreach (int numb in numbers)
            {
                if (numb <= minNumber)
                {
                    minNumber = numb;
                }
            }
            return minNumber;
        }
    }
}
