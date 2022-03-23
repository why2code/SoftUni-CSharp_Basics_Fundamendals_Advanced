using System;

namespace AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = SubtractNumbers(SumNumbers(firstNumber, secondNumber), thirdNumber);
            Console.WriteLine(result);
        }



        static int SumNumbers(int a, int b)
        {
            return a + b;
        }

        static int SubtractNumbers(int a, int c)
        {
            return a - c;
        }
    }
}
