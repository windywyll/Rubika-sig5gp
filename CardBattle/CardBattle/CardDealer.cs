using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public class CardDealer
    {
        private readonly Random rand = new Random();
        private static readonly int suitsCount = Enum.GetValues(typeof(ColorEnum)).Length;
        private static readonly int valuesCount = Enum.GetValues(typeof(ValueCard)).Length;
        private List<Card> deck;

        public CardDealer()
        {
            createDeck();
        }

        public void regenerateDeck()
        {
            createDeck();
        }

        private void createDeck()
        {
            deck = new List<Card>();
            
            foreach(ColorEnum col in Enum.GetValues(typeof(ColorEnum)))
            {
                foreach (ValueCard val in Enum.GetValues(typeof(ValueCard)))
                {
                    deck.Add(new Card(val, col));
                }
            }
        }

        public Card randomCard()
        {
            var suit = (ColorEnum) rand.Next(suitsCount);
            var value = (ValueCard) rand.Next(valuesCount);

            return new Card(value, suit);
        }

        /*public List<Card> Deal(int n)
        {
            List<Card> hand = new List<Card>();
            Card temp;
            bool alreadyInHand;

            for(int i = 0; i < n; i++)
            {
                alreadyInHand = true;

                while(alreadyInHand)
                {
                    temp = randomCard();
                    if (!hand.Contains(temp))
                    {
                        alreadyInHand = false;
                        hand.Add(temp);
                    }
                }
            }

            return hand;
        }*/

        public List<Card> Deal(int n)
        {
            List<Card> hand = new List<Card>();
            int index;

            if(n > deck.Count)
            {
                throw new ArgumentException("not enough card in deck");
            }

            for(int i = 0; i < n; i++)
            {
                index = rand.Next(deck.Count);
                hand.Add(deck[index]);
                deck.RemoveAt(index);
            }

            return hand;
        }

        public IEnumerable<Card> Frob(IEnumerable<Card> deck)
        {
            IEnumerable<Card> list = deck.Where<Card>(card => (card.color == ColorEnum.HEARTS || card.color == ColorEnum.DIAMONDS));

            list = list.Select(card =>
            {
                if (card.value == ValueCard.ACE)
                    return new Card(ValueCard.TWO, card.color);
                return new Card((card.value + 1), card.color);
            });

            return list;
        }
    }
}
