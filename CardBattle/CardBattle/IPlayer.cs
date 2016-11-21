using CardBattle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    public interface IPlayer
    {
        void Initialize(int playerCount);
        void Deal(IEnumerable<Card> cards);
        int PlayCard();
        void ReceiveFoldResult(FoldResult result);
    }
}
