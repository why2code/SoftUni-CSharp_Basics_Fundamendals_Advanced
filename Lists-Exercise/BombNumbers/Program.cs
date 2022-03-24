using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbersTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersToExplode = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] bombs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int bombValue = bombs[0];
            int bombPower = bombs[1];

            while (true)
            {

                int bombIndexInList = numbersToExplode.IndexOf(bombValue);
                if (bombIndexInList == -1)
                {
                    break;
                }
                //Right removal after explosion
                if (bombIndexInList + bombPower <= numbersToExplode.Count - 1)
                {
                    for (int i = bombIndexInList; i <= bombIndexInList + bombPower; i++)
                    {
                        numbersToExplode.RemoveAt(bombIndexInList);
                    }
                }
                else
                {
                    for (int i = bombIndexInList; i <= numbersToExplode.Count; i++)
                    {
                        numbersToExplode.RemoveAt(bombIndexInList);
                    }
                }

                //Left remover after explosion
                if (bombIndexInList - bombPower > 0)
                {
                    for (int i = bombIndexInList - bombPower; i < bombIndexInList; i++)
                    {
                        numbersToExplode.RemoveAt(bombIndexInList - bombPower);
                    }
                }
                else
                {
                    for (int i = 0; i < bombIndexInList; i++)
                    {
                        numbersToExplode.RemoveAt(0);
                    }
                }

            }
            Console.WriteLine(numbersToExplode.Sum());

        }
    }
}
