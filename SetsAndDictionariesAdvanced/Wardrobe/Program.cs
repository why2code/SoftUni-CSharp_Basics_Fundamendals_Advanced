using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothesType = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    foreach (var cloth in clothesType)
                    {
                        if (!wardrobe[color].ContainsKey(cloth))
                        {
                            wardrobe[color].Add(cloth, 1);
                        }
                        else
                        {
                            wardrobe[color][cloth]++;
                        }
                    }
                }
                else
                {
                    foreach (var cloth in clothesType)
                    {

                        if (!wardrobe[color].ContainsKey(cloth))
                        {
                            wardrobe[color][cloth] = 1;
                        }
                        else
                        {
                            wardrobe[color][cloth]++;
                        }
                    }
                }
            }

            //Reading the clothes to search for
            string[] dressToFind = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string colorToFind = dressToFind[0];
            string exactDress = dressToFind[1];

            //Final printout of the wardrobe, including the searched cloth  - if found
            foreach (var color in wardrobe.Keys)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var cloth in wardrobe[color].Keys)
                {
                    if (wardrobe.ContainsKey(colorToFind))
                    {
                        if (wardrobe[colorToFind].ContainsKey(exactDress)
                            && color == colorToFind
                            && cloth == exactDress)
                        {
                            Console.WriteLine($"* {cloth} - {wardrobe[color][cloth]} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {cloth} - {wardrobe[color][cloth]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {wardrobe[color][cloth]}");
                    }

                }
            }

        }
    }
}
