using System;
using System.Linq;

namespace ZigZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arraysLenght = int.Parse(Console.ReadLine());

            int[] arrayOne = new int[arraysLenght];
            int[] arrayTwo = new int[arraysLenght];

            for (int i = 2; i < arraysLenght + 2; i++) //starting cycle from 2 so we can use i % 2 == 0 to switch the zig-zag
            {

                if (i % 2 == 0)
                {
                    int[] tempArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    arrayOne[i - 2] = tempArray[0];
                    arrayTwo[i - 2] = tempArray[1];


                }
                else
                {
                    int[] tempArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    arrayOne[i - 2] = tempArray[1];
                    arrayTwo[i - 2] = tempArray[0];
                }
            }

            Console.WriteLine(String.Join(" ", arrayOne));
            Console.WriteLine(String.Join(" ", arrayTwo));
        }
    }
}
