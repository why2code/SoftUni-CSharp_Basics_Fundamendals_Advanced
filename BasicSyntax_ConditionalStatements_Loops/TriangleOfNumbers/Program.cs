using System;

namespace Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (j == i)
                    {
                        Console.WriteLine(i);

                    }
                    else
                    {
                        Console.Write($"{i} ");
                    }
                }
            }

        }
    }
}
