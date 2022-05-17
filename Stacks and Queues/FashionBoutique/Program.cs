using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> clothes = new Stack<int>(input);
            int capacity = int.Parse(Console.ReadLine());
            
            int addedClothesValue = 0;
            int usedRacksCount = 0;
            while (clothes.Count > 0)
            {
                addedClothesValue += clothes.Peek();
                if (addedClothesValue >= capacity)
                {
                    if (addedClothesValue == capacity)
                    {
                        clothes.Pop();
                    }
                    usedRacksCount++;
                    addedClothesValue = 0;
                }
                else
                {
                    clothes.Pop();
                }

            }

            //last check if any remaining clothes were left from the pile left after the last rack was filled
            if (addedClothesValue > 0)
            {
                usedRacksCount++;
            }
            Console.WriteLine(usedRacksCount);
        }
    }
}
