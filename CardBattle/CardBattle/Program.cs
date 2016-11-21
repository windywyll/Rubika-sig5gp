using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

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

            CardDealer dealer = new CardDealer();

            //Card c = dealer.randomCard();

            //Console.WriteLine("Random Card : " + c);

            //List<Card> hand = dealer.Deal(10);
            //Console.WriteLine("my hand bs : " + string.Join(", ", hand.Select(c => c.ToString()).ToArray()));
            //hand = dealer.Frob(hand).ToList();
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
    }
}
