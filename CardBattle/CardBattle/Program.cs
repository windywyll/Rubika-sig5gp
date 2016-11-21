using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardBattle.Models;
using System.Diagnostics;
using System.IO;

namespace CardBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Card aceOfSpades = new Card(ValueCard.ACE, ColorEnum.SPADES);
            //Card aceOfSpades2 = new Card(ValueCard.ACE, ColorEnum.SPADES);
            //Card aceOfDiamonds = new Card(ValueCard.ACE, ColorEnum.DIAMONDS);
            //Card sevenOfClubs = new Card(ValueCard.SEVEN, ColorEnum.CLUBS);

            //Console.WriteLine("Created card 1 : " + aceOfSpades);
            //Console.WriteLine("Created card 2 : " + aceOfSpades2);
            //Console.WriteLine("Created card 3 : " + aceOfDiamonds);
            //Console.WriteLine("Created card 4 : " + sevenOfClubs);

            //Console.WriteLine("1 == 2 : " + (aceOfSpades == aceOfSpades2));
            //Console.WriteLine("3 == 4 : " + (aceOfDiamonds == sevenOfClubs));
            //Console.WriteLine("1 != 2 : " + (aceOfSpades != aceOfSpades2));
            //Console.WriteLine("3 != 4 : " + (aceOfDiamonds != sevenOfClubs));
            //Console.WriteLine("1 > 3 : " + (aceOfSpades > aceOfDiamonds));
            //Console.WriteLine("1 < 3 : " + (aceOfSpades < aceOfDiamonds));
            //Console.WriteLine("4 < 1 : " + (sevenOfClubs < aceOfSpades));
            //Console.WriteLine("4 > 1 : " + (sevenOfClubs > aceOfSpades));
            //Console.WriteLine("1 <= 2 : " + (aceOfSpades <= aceOfSpades2));
            //Console.WriteLine("3 >= 4 : " + (aceOfDiamonds >= sevenOfClubs));

            //CardDealer dealer = new CardDealer();

            //Card c = dealer.randomCard();

            //Console.WriteLine("Random Card : " + c);

            //List<Card> hand = dealer.Deal(10);
            //Console.WriteLine("my hand bs : " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));
            //hand.Sort();
            //Console.WriteLine("my hand as : " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            /*var watch = new Stopwatch();
            watch.Start();
            for(int i = 100000; i > 0; i--)
            {
                dealer.regenerateDeck();
                dealer.Deal(32);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);*/

            //List<ulong> fiboseq = FibonacciFuncs.FirstNFibo(90).ToList();
            //int i = 0;
            //foreach (ulong n in fiboseq)
            //{
            //    Console.WriteLine("Fibo " + i + " :" + n);
            //    i++;
            //}

            //Console.WriteLine(FibonacciFuncs.NthMultipleFibo(10, 5));

            //Console.WriteLine("Div premiers : " + string.Join(", ", FibonacciFuncs.Divisors(60).Select(d => d.ToString()).ToArray()));

            //Console.WriteLine("Div premiers : " + string.Join(", ", FibonacciFuncs.DivisorsFromFibo(15, 3).Select(d => d.ToString()).ToArray()));

            Console.ReadLine();
        }

        private static void MainFibo()
        {
            var i = 0;
            Console.WriteLine("Fibo:");
            foreach (var f in Fibo.FirstFibos(90))
            {
                Console.WriteLine(f);
            }

            Console.WriteLine("10° multiple de 5 de fibo: " + Fibo.NthMultipleFibo(10, 5));

            Console.WriteLine("les diviseurs premiers de 23 sont: " + string.Join(", ", Fibo.Divisors(23).Select(d => d.ToString()).ToArray()));

            Console.WriteLine("les diviseurs premiers des 15 premiers nombres de fibonnaccis multiples de 3 sont: " +
                string.Join(", ", Fibo.DivisorsFromFibo(15, 3).Select(d => d.ToString()).ToArray())
                );

            Console.ReadLine();
        }

        public static void MainCard()
        {

            Func<Values, Card> heartsFactory = (v => new Card(v, Suit.Hearts));

            var nineOfHearts = heartsFactory(Values.Nine);

            var spadesAce = new Card(Values.Ace, Suit.Spades);

            Console.WriteLine("I created a card: " + spadesAce);

            var dealer = new CardDealer();
            for (var i = 0; i < 100; i++)
            {
                var deck = new List<Card>();
                for (var j = 0; j < 10; j++)
                {
                    dealer.Shuffle();

                    deck.AddRange(dealer.Deal(52));
                }

                deck.Sort();

                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));
            }

            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with .Net's built-in sort.");

            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                var deck = new List<Card>();
                for (var j = 0; j < 10; j++)
                {
                    dealer.Shuffle();

                    deck.AddRange(dealer.Deal(52));
                }

                Sort.Insertion(deck);

                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the insertion sort.");

            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                var deck = new List<Card>();
                for (var j = 0; j < 10; j++)
                {
                    dealer.Shuffle();

                    deck.AddRange(dealer.Deal(52));
                }
                Sort.Bubble(deck);
                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the bubble sort.");

            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                var deck = new List<Card>();
                for (var j = 0; j < 10; j++)
                {
                    dealer.Shuffle();

                    deck.AddRange(dealer.Deal(52));
                }
                Sort.Shake(deck);
                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the shake sort.");

            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                var deck = new List<Card>();
                for (var j = 0; j < 10; j++)
                {
                    dealer.Shuffle();

                    deck.AddRange(dealer.Deal(52));
                }
                deck = Sort.MergeSort(deck);
                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the merge sort.");


            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                var deck = new List<Card>();
                for (var j = 0; j < 10; j++)
                {
                    dealer.Shuffle();

                    deck.AddRange(dealer.Deal(52));
                }
                deck = Sort.QuickSort(deck);
                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the quick sort.");

            ComparisonMetrics.Instance.Reset();
            for (var i = 0; i < 100; i++)
            {
                var deck = new List<Card>();
                for (var j = 0; j < 10; j++)
                {
                    dealer.Shuffle();

                    deck.AddRange(dealer.Deal(52));
                }
                deck = deck.OrderBy(c => c).ToList();
                //Console.WriteLine("My hand contains " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));

            }
            Console.WriteLine("It took me " + ComparisonMetrics.Instance.ComparisonCount + " comparisons to sort 100 decks with the Linq sort.");


            Console.ReadLine();

        }

    }
}
