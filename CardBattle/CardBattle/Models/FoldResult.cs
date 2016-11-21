using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle.Models
{
    public class FoldResult
    {
        public FoldResult(IEnumerable<Card> cards, int winnerIndex, string winnerName)
        {
            CardsPlayed = cards;
            Winner = winnerIndex;
            WinnerName = winnerName;

        }

        public IEnumerable<Card> CardsPlayed { get; private set; }
        public int Winner { get; private set; }
        public string WinnerName { get; private set; }
    }
}
