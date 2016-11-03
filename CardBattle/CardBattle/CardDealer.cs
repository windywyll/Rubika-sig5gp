using CardBattle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public class CardDealer
    {
        private readonly Random _rand = new Random();
        private static readonly int _suitsCount = Enum.GetValues(typeof(Suit)).Length;
        private static readonly int _valuesCount = Enum.GetValues(typeof(Values)).Length;

        public Card RandomCard()
        {
            var suit = (Suit)_rand.Next(_suitsCount);
            var value = (Values)_rand.Next(_valuesCount);
            return new Card(value, suit);
        }

    }
}
