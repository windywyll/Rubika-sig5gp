using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardBattle.Models;

namespace CardBattle
{
    class Sarkhan : IPlayer
    {
        private string realName;

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
                return realName;
            }
        }

        private int numberOfPlayer, myId;
        private List<Card> hand;
        private enum playStyle{ C, D, R };
        private playStyle ps;
        private Random r;

        public void Deal(IEnumerable<Card> cards)
        {
            hand = new List<Card>(cards);
            choosePlayStyle();
        }

        public void Initialize(int playerCount, int position)
        {
            numberOfPlayer = playerCount;
            myId = position;
        }

        public Card PlayCard()
        {
            Card myCard = null;

            if(ps == playStyle.C)
            {
                myCard = hand[0];
                hand.RemoveAt(0);
            }

            if (ps == playStyle.D)
            {
                myCard = hand[hand.Count-1];
                hand.RemoveAt(hand.Count-1);
            }

            if (ps == playStyle.R)
            {
                int indexMyCard = r.Next(hand.Count);
                myCard = hand[indexMyCard];
                hand.RemoveAt(indexMyCard);
            }

            return myCard;
        }

        public void ReceiveFoldResult(FoldResult result)
        {
            throw new NotImplementedException();
        }

        private void choosePlayStyle()
        {
            hand.Sort();
            ps = playStyle.R;
            r = new Random();
            realName = "Sarkhan Le Fou";

            bool foundFirstNine = false;
            int i = 0;

            while(!foundFirstNine || i == hand.Count)
            {
                if(hand[i].Value == Values.Nine)
                {
                    foundFirstNine = true;
                }
                else
                {
                    i++;
                }
            }

            if (foundFirstNine)
            {
                if (i > (hand.Count - 1) / 2)
                {
                    ps = playStyle.C;
                    realName = "Sarkhan Vol";
                }

                if (i > (hand.Count - 1) / 2)
                {
                    ps = playStyle.D;
                    realName = "Sarkhan Inaltéré";
                }
            }
        }
    }
}
