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

        private List<Card> _availableCards;

        public CardDealer()
        {
            Shuffle();
        }

        public int RemainingCards
        {
            get
            {
                return _availableCards.Count;
            }
        }

        public Card RandomCard()
        {
            if(_availableCards.Count == 0)
            {
                throw new InvalidOperationException("Nocard available.");
            }

            var index = _rand.Next(_availableCards.Count);

            var result = _availableCards[index];

            _availableCards.RemoveAt(index);

            return result;
        }

        public void Shuffle()
        {
            var list = new List<Card>();
            for(var i = 0; i<_suitsCount; i++)
            {
                for (var j = 0; j< _valuesCount;j++)
                {
                    list.Add(new Card((Values)j, (Suit)i));
                } 
            }

            _availableCards = list;
        }

        public List<Card> Deal(int n)
        {
            if(n > _availableCards.Count)
            {
                throw new ArgumentException("Not enough cards available");
            }

            var result = new List<Card>();
            for(var i = 0; i<n; i++)
            {
                result.Add(RandomCard());
            }
            return result;
        }


    }
}
