using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<long> stations = new Queue<long>();

            for (int i = 0; i < n; i++)
            {
                int[] currentStation = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int availableTravelDistanceForTheCurrentStation = currentStation[0] - currentStation[1];
                stations.Enqueue(availableTravelDistanceForTheCurrentStation);
            }

            if (stations.Sum() < 0)
            {
                return;
            }


            for (int i = 0; i < n; i++)
            {
                bool hasTravelledSuccessfully = true;
                long totalDistance = 0;

                foreach (var item in stations)
                {
                    totalDistance += item;
                    if (totalDistance < 0)
                    {
                        hasTravelledSuccessfully = false;
                        break;
                    }
                }

                if (hasTravelledSuccessfully)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    stations.Enqueue(stations.Dequeue());
                }

            }


        }
    }
}
