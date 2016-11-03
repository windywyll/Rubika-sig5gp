using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    class CardDealer
    {
        Array randCol, randVal;
        Random rand;

        public CardDealer()
        {
            randCol = Enum.GetValues(typeof(ColorEnum));
            randVal = Enum.GetValues(typeof(ValueCard));
            rand = new Random();
        }

        public Card randomCard()
        {
            ColorEnum _colorRandCard = (ColorEnum)randCol.GetValue(rand.Next(randCol.Length));
            ValueCard _valueRandCard = (ValueCard)randVal.GetValue(rand.Next(randVal.Length));

            return new Card(_valueRandCard, _colorRandCard);
        }
    }
}
