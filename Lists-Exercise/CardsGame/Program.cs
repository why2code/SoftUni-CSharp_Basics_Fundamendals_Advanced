using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> deckOne = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> deckTwo = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (deckOne.Count > 0 && deckTwo.Count > 0)
            {
                CompareCardsInDeck(deckOne, deckTwo);
            }

            if (deckOne.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {deckOne.Sum()}");
            }
            else if (deckTwo.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {deckTwo.Sum()}");
            }
        }

        static void CompareCardsInDeck(List<int> firstList, List<int> secondList)
        {
            int cardOne = firstList[0];
            int cardTwo = secondList[0];

            if (cardOne > cardTwo)
            {
                int winningCard = firstList[0];
                firstList.RemoveAt(0);
                firstList.Add(winningCard);
                firstList.Add(cardTwo);
                secondList.RemoveAt(0);
            }
            else if (cardTwo > cardOne)
            {
                int winningCard = secondList[0];
                secondList.RemoveAt(0);
                secondList.Add(winningCard);
                secondList.Add(cardOne);
                firstList.RemoveAt(0);
            }
            else if (cardOne == cardTwo)
            {
                firstList.RemoveAt(0);
                secondList.RemoveAt(0);
            }
        }
    }
}
