using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle.Models
{
    public class Card
    {
        public Card(Values value, Suit suit)
        {
            _suit = suit;
            Value = value;
        }

        private readonly Suit _suit;
        public Suit Suit
        {
            get
            {
                return _suit;
            }
        }

        public Values Value { get; private set; }

        public override string ToString()
        {
            return Value + " of " + Suit; ;
        }
    }
}
