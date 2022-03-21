using System;
using System.Linq;

namespace CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] arrayOne = Console.ReadLine().Split(' ');
            string[] arrayTwo = Console.ReadLine().Split(' ');


            foreach (var item in arrayTwo)
            {
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    if (item == arrayOne[i])
                    {

                        if (i <= arrayOne.Length - 1)
                        {

                            Console.Write($"{arrayOne[i]} ");
                        }
                        else
                        {
                            Console.Write($"{arrayOne[i]}");

                        }

                    }
                }
            }


        }
    }
}