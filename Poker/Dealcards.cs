using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DealCards : Deck
    {
        private Card[] playerHand;
        private Card[] computerHand;

        private Card[] sortedPlayerHand;
        private Card[] sortedComputerHand;

        public DealCards()
        {
            playerHand = new Card[5];
            sortedPlayerHand = new Card[5];
            computerHand = new Card[5];
            sortedComputerHand = new Card[5];

        }

        public void Deal()
        {
            CreateDeck();
            GetHand();
            SortCards();
            DisplayCards();
            EvaluateHands();
        }

        public void GetHand()
        {
            //5 cards for the player
            for (int i = 0; i < 5; i++)
                playerHand[i] = GetDeck[i];

            //5 cards for the computer.  Notice the index
            for (int i = 5; i < 10; i++)
                computerHand[i - 5] = GetDeck[i];
        }

        public void SortCards()
        {
            var queryPlayer = from hand in playerHand
                              orderby hand.Value
                              select hand;

            var queryComputer = from hand in computerHand
                                orderby hand.Value
                                select hand;

            var index = 0;
            foreach (var e in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = e;
                index++;
            }

            index = 0;
            foreach (var e in queryComputer.ToList())
            {
                sortedComputerHand[index] = e;
                index++;
            }
        }

        public void DisplayCards()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            int x = 0; // position of cursor. we move it left and right
            int y = 1; // y position of curser, we move it up and down.
            // display player hand
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Players's Hand");
            for (int i = 0; i < 5; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(sortedPlayerHand[i], x, y);
                x++;
            }
            y = 15; //move the row of computer cards below the player's cards
            x = 0; //reset x position
            Console.SetCursorPosition(x, y - 1);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Computers Hand");
            for (int i = 5; i < 10; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(sortedComputerHand[i - 5], x, y);
                x++;
            }
        }

        public void EvaluateHands()
        {
            //create player's and computer's evaluation object(passing Sorted Hand to Constructor)
            HandEvaluator playerHandEval = new HandEvaluator(sortedPlayerHand);
            HandEvaluator computerHandEval = new HandEvaluator(sortedComputerHand);

            //get the players and computers hand
            Hand playerHand = playerHandEval.EvaluateHand();
            Hand computerHand = computerHandEval.EvaluateHand();

            //display each hand
            Console.WriteLine("\n\n\n\n\nPlayer's Hand: " + playerHand);
            Console.WriteLine("\nComputer's Hand: " + computerHand);

            //evalue hands
            if (playerHand > computerHand)
            {
                Console.WriteLine("Player WINS");
            }
            else if (playerHand < computerHand)
            {
                Console.WriteLine("Computer WINS!");
            }
            else // if hands are the same eval the values
            {
                if (playerHandEval.HandValues.Total > computerHandEval.HandValues.Total)
                    Console.WriteLine("Player WINS!");
                else if (playerHandEval.HandValues.Total < computerHandEval.HandValues.Total)
                    Console.WriteLine("Computer WINS!");
                else if (playerHandEval.HandValues.HightCard > computerHandEval.HandValues.HightCard)
                    Console.WriteLine("Player WINS!");
                else if (playerHandEval.HandValues.HightCard < computerHandEval.HandValues.HightCard)
                    Console.WriteLine("Computer WINS!");
                else
                    Console.WriteLine("DRAW!");
            }

        }
    }
}
