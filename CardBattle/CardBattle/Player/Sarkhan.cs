using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardBattle.Models;
using CardBattle.Infrastructure;

namespace CardBattle.Player
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
        private List<Card> cardPlayed;
        private enum playStyle{ Ex, D, R, M};
        private playStyle ps;
        private RandomProvider r;
        private bool extremePlay;


        public void Deal(IEnumerable<Card> cards)
        {
            hand = new List<Card>(cards);
            extremePlay = true;
            hand.Sort();
            
        }

        public void Initialize(int playerCount, int position)
        {
            numberOfPlayer = playerCount;
            myId = position;
            cardPlayed = new List<Card>();
        }

        public Card PlayCard()
        {
            Card myCard = null;

            choosePlayStyle();

            if (ps == playStyle.Ex && hand.Count > 0)
            {
                if (extremePlay)
                {
                    myCard = hand[0];
                    hand.RemoveAt(0);
                    extremePlay = false;
                }
                else
                {
                    myCard = hand[hand.Count - 1];
                    hand.RemoveAt(hand.Count - 1);
                    extremePlay = true;
                }
            }

            if(ps == playStyle.M && hand.Count > 0)
            {
                myCard = hand[hand.Count / 2];
                hand.RemoveAt(hand.Count / 2);
            }

            if (ps == playStyle.D && hand.Count > 0)
            {
                myCard = hand[hand.Count-1];
                hand.RemoveAt(hand.Count-1);
            }

            if(ps == playStyle.R && hand.Count > 0)
            {
                int maxRange = hand.Count, minRange = 0;
                int indexMyCard = r.Random.Next(minRange,maxRange);
                myCard = hand[indexMyCard];
                hand.RemoveAt(indexMyCard);
            }

            return myCard;
        }

        public void ReceiveFoldResult(FoldResult result)
        {
            cardPlayed.AddRange(result.CardsPlayed);
            cardPlayed.Sort();
        }

        private void choosePlayStyle()
        {
            ps = playStyle.R;
            r = new RandomProvider();
            realName = "Sarkhan Le Fou";

            bool foundHighValue = false;
            bool foundExtremeValue = false;
            int i = 0;
            int indexHigh = hand.Count - 1;
            int indexExtreme = hand.Count - 1;

            while(i < hand.Count)
            {
                if(hand[i].Value >= Values.Nine)
                {
                    foundHighValue = true;
                    indexHigh = i;
                }

                if(hand[i].Value >= Values.Queen)
                {
                    foundExtremeValue = true;
                    indexExtreme = i;
                }

                i++;
            }

            if (foundHighValue)
            {
                if (indexHigh < (hand.Count - 1) / 3)
                {
                    ps = playStyle.M;
                    realName = "Sarkhan Inaltéré";
                }
                else
                {
                    ps = playStyle.Ex;
                    realName = "Sarkhan Vol";
                }
            }

            if(foundExtremeValue)
            {
                if(indexExtreme < (hand.Count - 1) / 3)
                {
                    ps = playStyle.D;
                    realName = "Sarkhan LangueDragon";
                }
            }
        }
    }
}
