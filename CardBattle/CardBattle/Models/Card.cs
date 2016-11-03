using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        public ValueCard value { get; private set; }
        public ColorEnum color { get; private set; }

        public Card(ValueCard _val, ColorEnum _col)
        {
            value = _val;
            color = _col;
        }

        public override string ToString()
        {
            return value + " OF " + color;
        }

        public bool Equals(Card other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            
            return (this.color == other.color && this.value == other.value);
        }

        public override bool Equals(object obj)
        {
            var otherCard = obj as Card;

            return Equals(otherCard);
        }

        public static bool operator == (Card card1, Card card2)
        {
            if(Object.ReferenceEquals(card1, null))
            {
                return Object.ReferenceEquals(card2, null);
            }

            return card1.Equals(card2);
        }

        public static bool operator != (Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        public int CompareTo(Card other)
        {
            if (other == null)
                return 1;

            if (this.value.CompareTo(other.value) != 0)
                return this.value.CompareTo(other.value);
            else
                return this.color.CompareTo(other.color);
        }

        public static bool operator > (Card card1, Card card2)
        {
            if (card1 == null)
                return false;

            if (card1.CompareTo(card2) > 0)
                return true;
            return false;
        }

        public static bool operator < (Card card1, Card card2)
        {
            if (card1 == null)
                return true;

            if (card1.CompareTo(card2) < 0)
                return true;
            return false;
        }

        public static bool operator >= (Card card1, Card card2)
        {
            if (card1 == null)
                return false;

            if (card1.CompareTo(card2) >= 0)
                return true;
            return false;
        }

        public static bool operator <= (Card card1, Card card2)
        {
            if (card1 == null)
                return true;

            if (card1.CompareTo(card2) <= 0)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return 3 * value.GetHashCode() + color.GetHashCode();
        }
    }
}
