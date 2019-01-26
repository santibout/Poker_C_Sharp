using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DrawCards
    {
        //draw card outlines
        public static void DrawCardOutline(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int X = x * 12;
            int Y = y;

            Console.SetCursorPosition(X, Y);
            //width is 10 spaces the line going down will be the other 2
            Console.Write(" __________\n");//Top edge of the card

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(X, Y + 1 + i);

                if (i != 9)
                    Console.WriteLine("|          |");//Left and right edges of card
                else
                    Console.WriteLine("|__________|");//Bottom edge of card
            }
        }
        //Displays suit and value of card inside its outline
        public static void DrawCardSuitValue(Card c, int x, int y)
        {
            char s = ' ';
            int X = x * 12;
            int Y = y;

            //Encode each byte array from the CodePage437 into character
            //hearts and diamonds are red and clubs and spades are black
            switch (c.Suit)
            {
                case Card.SUIT.HEARTS:
                    s = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.DIAMONDS:
                    s = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.CLUBS:
                    s = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Card.SUIT.SPADES:
                    s = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
            //Display encoded character and value of card
            Console.SetCursorPosition(X + 5, Y + 5);
            Console.Write(s);
            Console.SetCursorPosition(X + 4, Y + 7);
            Console.WriteLine(c.Value);
            Console.SetCursorPosition(X + 4, Y + 8);
            Console.WriteLine(c.Suit);

        }
    }
}
