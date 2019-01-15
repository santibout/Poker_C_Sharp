using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            DrawCards.DrawCardOutline(0, 0);

            Card card = new Card();
            card.Suit = Card.SUIT.SPADES;
            card.Value = Card.VALUE.ACE;
            DrawCards.DrawCardSuitValue(card, 0, 0);
            //Deck deck = new Deck();

            Console.ReadKey();
        }
    }
}
