using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle.Models
{
    public class Card : IEquatable<Card>, IComparable<Card>
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
            return Value + " of " + Suit;
            ;
        }

        public bool Equals(Card other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.Suit == other.Suit && this.Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            var otherCard = obj as Card;

            return Equals(otherCard);

        }

        public int CompareTo(Card other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            ComparisonMetrics.Instance.Signal();

            var valueComparison = this.Value.CompareTo(other.Value);
            if (valueComparison != 0)
            {
                return valueComparison;
            }
            else
            {
                return this.Suit.CompareTo(other.Suit);
            }
        }

        public static bool operator ==(Card card1, Card card2)
        {
            if (Object.ReferenceEquals(card1, null))
            {
                return Object.ReferenceEquals(card2, null);
            }
            return card1.Equals(card2);
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        public override int GetHashCode()
        {
            return 3 * Value.GetHashCode() + Suit.GetHashCode();
        }
    }
}
