using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Card
    {
        public SUIT Suit { get; set; }
        public VALUE Value { get; set; }

        public enum SUIT
        {
            DIAMOND,
            HEART,
            CLUB,
            SPADE
        }

        public enum VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }
    }
}
