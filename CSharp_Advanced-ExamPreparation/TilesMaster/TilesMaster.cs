using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class TilesMaster
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse).ToArray());

            //Dictionary<string, int> sinkAreas = new Dictionary<string, int>()
            //{
            //    {"Sink", 40 },
            //    {"Oven", 50 },
            //    {"Countertop", 60 },
            //    {"Wall", 70 }
            //};


            Dictionary<string, int> completedTiles = new Dictionary<string, int>()
            {
                {"Countertop", 0},
                {"Floor", 0 },
                {"Oven", 0 },
                {"Sink", 0 },
                {"Wall", 0 }

            };

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int currWhileTile = whiteTiles.Peek();
                int currGreyTile = greyTiles.Peek();
                if (currWhileTile == currGreyTile)
                {
                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                    int totalTileArea = currGreyTile + currWhileTile;
                    if (totalTileArea == 40)
                    {
                        completedTiles["Sink"] += 1;
                    }
                    else if (totalTileArea == 50)
                    {
                        completedTiles["Oven"] += 1;

                    }
                    else if (totalTileArea == 60)
                    {
                        completedTiles["Countertop"] += 1;

                    }
                    else if (totalTileArea == 70)
                    {
                        completedTiles["Wall"] += 1;

                    }
                    else
                    {
                        completedTiles["Floor"] += 1;
                    }


                }
                else
                {
                    currWhileTile = currWhileTile / 2;
                    whiteTiles.Pop();
                    whiteTiles.Push(currWhileTile);

                    greyTiles.Dequeue();
                    greyTiles.Enqueue(currGreyTile);
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.Write("White tiles left: ");
                Console.WriteLine(string.Join(", ", whiteTiles));
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.Write("Grey tiles left: ");
                Console.WriteLine(string.Join(", ", greyTiles));
            }

            //completedTiles.OrderBy(x => x.Value);
            foreach (var area in completedTiles.OrderByDescending(x => x.Value))
            {
                if (area.Value > 0)
                {
                    Console.WriteLine($"{area.Key}: {area.Value}");
                }
            }
        }
    }
}
