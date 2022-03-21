using System;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                double numberToAdd = double.Parse(Console.ReadLine());
                result += numberToAdd;
            }
            
            Console.WriteLine($"Result: {result}");

        }
    }
}
