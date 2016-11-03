using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardBattle.Models;

namespace CardBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            var spadesAce = new Card(Values.Ace, Suit.Spades);

            Console.WriteLine("I created a card: " + spadesAce);

            var dealer = new CardDealer();
            for (var i = 0; i < 100; i++)
            {
                dealer.Shuffle();
                var hand = dealer.Deal(52);
                hand.Sort();

                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));
            }

            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with .Net's built-in sort.");

            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                dealer.Shuffle();
                var hand = dealer.Deal(52);
                Sort.Insertion(hand);

                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the insertion sort.");

            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                dealer.Shuffle();
                var hand = dealer.Deal(52);
                Sort.Bubble(hand);
                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the bubble sort.");

            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                dealer.Shuffle();
                var hand = dealer.Deal(52);
                Sort.Shake(hand);
                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the shake sort.");

            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                dealer.Shuffle();
                var hand = dealer.Deal(52);
                hand = Sort.MergeSort(hand);
                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the merge sort.");


            Console.ReadLine();
        }
    }
}
