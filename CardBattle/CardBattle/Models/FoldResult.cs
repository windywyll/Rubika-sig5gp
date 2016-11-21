using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle.Models
{
    public class FoldResult
    {
        IEnumerable<Card> CardsPlayed { get; set; }
        int Winner { get; set; }
    }
}
