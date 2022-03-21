using System;
using System.Linq;

namespace TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] listOfDigits = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool flag = false;

            //14 24 3 19 15 17
            //0  1  2  3  4 5
            for (int i = 0; i < listOfDigits.Length; i++)
            {

                flag = false;
                if (i + 1 == listOfDigits.Length)
                {
                    Console.Write($"{listOfDigits[i]}");
                    break;
                }

                for (int k = i + 1; k < listOfDigits.Length; k++)
                {
                    if (listOfDigits[i] <= listOfDigits[k])
                    {
                        flag = true;
                        break;
                    }
                }


                if (!flag)
                {
                    Console.Write($"{listOfDigits[i]} ");

                }

            }

        }
    }
}
