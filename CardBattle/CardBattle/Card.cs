using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardBattle
{
    class Card
    {
        public ValueCard value { get; set; }
        public ColorEnum color { get; set; }

        public Card(ValueCard _val, ColorEnum _col)
        {
            value = _val;
            color = _col;
        }

        public override string ToString()
        {
            return value + " OF " + color;
        }
    }
}
