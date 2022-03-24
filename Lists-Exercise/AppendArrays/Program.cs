using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> initialList = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> resultList = new List<string>();

            ListSwap(initialList);
            foreach (var item in initialList)
            {
                resultList.AddRange(item.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
            }
                        

            Console.WriteLine(string.Join(" ", resultList));

        }

        static void ListSwap(List<string> list)
        {

            for (int i = list.Count - 1; i > 0; i--)
            {
                string firstSwap = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                list.Insert(list.Count - i, firstSwap);
            }
        }

        public static string RemoveWhitespace(string input)
        {

            input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return input;
        }


    }
}
