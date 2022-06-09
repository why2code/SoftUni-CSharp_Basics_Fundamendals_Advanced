using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            //===============================================================================
            //5. Generic Count Method String  
            int n = int.Parse(Console.ReadLine());
            var elements = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string currElement = Console.ReadLine();
                elements.Add(currElement);
            }

            string comparer = Console.ReadLine();
            Console.WriteLine(CountOfGreaterThan<string>(elements, comparer));
            

            ////===============================================================================
            ////4. Generic Swap Method Integer 
            //int n = int.Parse(Console.ReadLine());
            //var allBoxes = new List<Box<int>>();
            //for (int i = 0; i < n; i++)
            //{
            //    var box = new Box<int>(int.Parse(Console.ReadLine()));
            //    allBoxes.Add(box);

            //}

            //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int index1 = indexes[0];
            //int index2 = indexes[1];
            //var swappedBoxes = SwapIndexes(allBoxes, index1, index2);

            //foreach (var box in swappedBoxes)
            //{
            //    Console.WriteLine(box.ToString());
            //}


            ////===============================================================================
            ////3. Generic Swap Method String 
            //int n = int.Parse(Console.ReadLine());
            //var allBoxes = new List<Box<string>>();
            //for (int i = 0; i < n; i++)
            //{
            //    var box = new Box<string>(Console.ReadLine());
            //    allBoxes.Add(box);

            //}

            //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int index1 = indexes[0];
            //int index2 = indexes[1];
            //var swappedBoxes = SwapIndexes(allBoxes, index1, index2);

            //foreach (var box in swappedBoxes)
            //{
            //    Console.WriteLine(box.ToString());
            //}

            ////===============================================================================
            ////2. Generic Box of Integers
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine();
            //    var box = new Box<int>(int.Parse(input));
            //    Console.WriteLine(box.ToString());
            //}

            ////===============================================================================
            ////1. Generic Box of String
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine();
            //    var box = new Box<string>(input);
            //    Console.WriteLine(box.ToString());
            //}
        }

        public static List<Box<T>> SwapIndexes<T>(List<Box<T>> boxes, int index1, int index2)
        {
            if ((index1 < 0 && index1 >= boxes.Count)
               || (index2 < 0 && index2 >= boxes.Count))
            {
                throw new ArgumentException("Invalid indexes outside of the boundrays of the List.");
            }

            var swapValue = boxes[index1];
            boxes[index1] = boxes[index2];
            boxes[index2] = swapValue;
            return boxes;
        }

        public static int CountOfGreaterThan<T>(List<T> list, T toCompare)
        where T : IComparable<T>
        {
            return list.Count(x => x.CompareTo(toCompare) > 0);
        }
    }
}
