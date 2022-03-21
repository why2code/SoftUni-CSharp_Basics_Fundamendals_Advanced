using System;

namespace StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string numb = Console.ReadLine();
            double totalFactorial = 1;
            double result = 0;

            for (int i = 0; i < numb.Length; i++)
            {
                char indexNumber = numb[i];
                int rotator = int.Parse(indexNumber.ToString());
                if (rotator == 0) // factorinbg Factoriel of 0;
                {
                    rotator = 1;
                }

                for (int j = 1; j <= rotator; j++)
                {
                    totalFactorial *= j;
                    if (j == rotator)
                    {
                        result += totalFactorial;
                        totalFactorial = 1;
                    }
                }

            }


            if (result == int.Parse(numb))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
