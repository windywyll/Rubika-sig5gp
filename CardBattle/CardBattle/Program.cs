using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Card c = new Card(ValueCard.ACE, ColorEnum.SPADES);

            Console.WriteLine("Created card : " + c.ToString());

            Console.ReadLine();
        }
    }
}
