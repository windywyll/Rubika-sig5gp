using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    class CardSorter
    {

        public static List<Card> insertionSort(List<Card> deck)
        {
            List<Card> temp = new List<Card>();
            bool notInserted;

            foreach(Card c in deck)
            {
                notInserted = true;

                for(int i = 0; i < temp.Count; i++)
                {
                    if(notInserted && c <= temp[i])
                    {
                        temp.Insert(i, c);
                        notInserted = false;
                    }
                }

                if (notInserted)
                    temp.Add(c);
            }

            return temp;
        }

        public static List<Card> bubbleSort(List<Card> deck)
        {
            List<Card> toSort = deck;
            bool sorted;
            Card temp;

            do
            {
                sorted = true;

                for(int i = 0; i < toSort.Count-1; i++)
                {
                    if(toSort[i] > toSort[i+1])
                    {
                        temp = toSort[i + 1];
                        toSort[i + 1] = toSort[i];
                        toSort[i] = temp;
                        sorted = false;
                    }
                }

            } while (!sorted);

            return toSort;
        }

        public static List<Card> shakeSort(List<Card> deck)
        {
            List<Card> toSort = deck;
            bool sorted;
            Card temp;

            do
            {
                sorted = true;

                for (int i = 0; i < toSort.Count - 1; i++)
                {
                    if (toSort[i] > toSort[i + 1])
                    {
                        temp = toSort[i + 1];
                        toSort[i + 1] = toSort[i];
                        toSort[i] = temp;
                        sorted = false;
                    }
                }

                for (int i = toSort.Count-1; i > 1; i--)
                {
                    if (toSort[i] < toSort[i - 1])
                    {
                        temp = toSort[i - 1];
                        toSort[i - 1] = toSort[i];
                        toSort[i] = temp;
                        sorted = false;
                    }
                }

            } while (!sorted);

            return toSort;
        }

        public static List<Card> fusionSort(List<Card> deck)
        {
            List<Card> toSort = deck;
            List<Card> firstHalf, secondHalf;

            if(toSort.Count == 1)
            {
                return toSort;
            }

            firstHalf = new List<Card>(toSort.Take((toSort.Count / 2)));
            toSort.RemoveRange(0, (toSort.Count / 2));
            secondHalf = toSort;

            firstHalf = fusionSort(firstHalf);
            secondHalf = fusionSort(secondHalf);

            toSort = new List<Card>();

            do
            {
                if (firstHalf.Count == 0)
                {
                    toSort.Add(secondHalf[0]);
                    secondHalf.RemoveAt(0);
                }
                else if (secondHalf.Count == 0)
                {
                    toSort.Add(firstHalf[0]);
                    firstHalf.RemoveAt(0);
                }
                else if (firstHalf[0] <= secondHalf[0])
                {
                    toSort.Add(firstHalf[0]);
                    firstHalf.RemoveAt(0);
                }
                else
                {
                    toSort.Add(secondHalf[0]);
                    secondHalf.RemoveAt(0);
                }

            } while (firstHalf.Count + secondHalf.Count > 0);

            return toSort;
        }

        public static List<Card> quickSort(List<Card> deck)
        {
            List<Card> toSort = deck;
            

            return toSort;
        }
    }
}
