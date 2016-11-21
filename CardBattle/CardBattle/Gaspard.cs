﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardBattle.Models;

namespace CardBattle
{
    class Gaspard : IPlayer //Version 1.0
    {
        public string Author
        {
            get {return "BonneFoi"; }
        }

        public string Name
        {
            get { return "Gaspard"; }
        }

        List<Card> myCards;
        public void Deal(IEnumerable<Card> cards)
        {
            myCards = new List<Card>(cards);
        }

        int nbPlayer;
        int ID;
        public void Initialize(int playerCount, int position)
        {
            nbPlayer = playerCount;
            ID = position;
        }

         enum gameMode
        {
            random,
            better,
            worst,
            mid,
            count
        }
        gameMode GM;

        public Card PlayCard()
        {
            Random rnd = new Random();
            GM = (gameMode) rnd.Next((int) gameMode.count);
            int CardId = 0;
            Card CardPlayed = myCards.ElementAt(CardId);
            myCards.Sort();
            switch (GM)
            {
                case gameMode.random:
                    CardId = rnd.Next(myCards.Count());
                    CardPlayed = myCards.ElementAt(CardId);
                break;
                case gameMode.better:
                    CardId = myCards.Count()-1;
                    CardPlayed = myCards.ElementAt(CardId);
                break;
                case gameMode.worst:
                    CardId = 0;
                    CardPlayed = myCards.ElementAt(CardId);
                break;
                case gameMode.mid:
                    CardId = myCards.Count()/2;
                    CardPlayed = myCards.ElementAt(CardId);
                break;
            }
            myCards.RemoveAt(CardId);
            return CardPlayed;
        }

        int nbGame = 0;
        int nbWin = 0;
        public void ReceiveFoldResult(FoldResult result)
        {
            nbGame++;
            if (result.WinnerName != "Gaspard")
            {
                Console.WriteLine(result.WinnerName + " is a cheater !");
            }
            else
            {
                if (nbWin > 0)
                {
                    if (nbGame / nbWin > 0.5) { Console.WriteLine("Gaspard always win !"); }
                    else { Console.WriteLine("Gaspard win again !"); }
                }
                else { Console.WriteLine("Gaspard win !"); }
                nbWin++;
            }
        }
    }
}
