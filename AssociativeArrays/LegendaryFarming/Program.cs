using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._0_LegendaryFarming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> specialItems = new Dictionary<string, double>()
            {
                ["shards"] = 0,
                ["motes"] = 0,
                ["fragments"] = 0
            };
            Dictionary<string, double> junkItems = new Dictionary<string, double>();
            string specialItemID = null;

            while (specialItemID == null)
            {
                string[] currentItemsFound = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < currentItemsFound.Length - 1; i += 2)
                {
                    double value = double.Parse(currentItemsFound[i]);
                    string typeOfItem = currentItemsFound[i + 1].ToLower();

                    if (typeOfItem == "shards" || typeOfItem == "fragments" || typeOfItem == "motes")
                    {
                        if (specialItems.ContainsKey(typeOfItem))
                        {
                            specialItems[typeOfItem] += value;
                        }
                        else
                        {
                            specialItems.Add(typeOfItem, value);
                        }

                        //checking for completed item (250 or more pieces gathered) to break the cycle
                        foreach (var item in specialItems)
                        {
                            if (item.Value >= 250)
                            {
                                string specialItem = item.Key;
                                if (specialItem == "shards")
                                {
                                    Console.WriteLine("Shadowmourne obtained!");
                                    specialItemID = "shards";
                                    break;
                                }
                                else if (specialItem == "fragments")
                                {
                                    Console.WriteLine("Valanyr obtained!");
                                    specialItemID = "fragments";
                                    break;
                                }
                                else if (specialItem == "motes")
                                {
                                    Console.WriteLine("Dragonwrath obtained!");
                                    specialItemID = "motes";
                                    break;
                                }
                            }
                        }
                        //if we have 250 or more of the special item, we break the cycle and reduce it`s value
                        if (specialItemID != null)
                        {
                            specialItems[specialItemID] -= 250;
                            break;
                        }


                    }
                    else
                    {
                        if (!junkItems.ContainsKey(typeOfItem))
                        {
                            junkItems.Add(typeOfItem, value);
                        }
                        else
                        {
                            junkItems[typeOfItem] += value;
                        }
                    }
                }


            }

            //final printout remaining items
            foreach (var item in specialItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
