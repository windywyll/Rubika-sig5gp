using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardBattle.Models;

namespace CardBattle
{
    class Sarkhan : IPlayer
    {
        public string Author
        {
            get
            {
                return "Jordan";
            }
        }

        public string Name
        {
            get
            {
                return "Sarkhan Le Fou";
            }
        }

        private int numberOfPlayer, myId;
        private List<Card> hand;

        public void Deal(IEnumerable<Card> cards)
        {
            hand = new List<Card>(cards);
            hand.Sort();
        }

        public void Initialize(int playerCount)
        {
            numberOfPlayer = playerCount;
        }

        public int PlayCard()
        {
            throw new NotImplementedException();
        }

        public void ReceiveFoldResult(FoldResult result)
        {
            throw new NotImplementedException();
        }
    }
}
