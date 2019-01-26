using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum Hand
    {
        Nothing,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HightCard { get; set; }
    }

    class HandEvaluator : Card
    {
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadesSum;
        private Card[] cards;
        private HandValue handValue;

        public HandEvaluator(Card[] sortedHand)
        {
            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadesSum = 0;
            cards = new Card[5];
            Cards = sortedHand;
            handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }

        public Hand EvaluateHand()
        {
            getNumberOfSuit();
            if (FourOfAKind())
                return Hand.FourOfAKind;
            else if (FullHouse())
                return Hand.FullHouse;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (ThreeOfAKind())
                return Hand.ThreeOfAKind;
            else if (TwoPairs())
                return Hand.TwoPair;
            else if (Pair())
                return Hand.Pair;

            //if player has nothing player with highest card wins
            handValue.HightCard = (int)cards[4].Value;
            return Hand.Nothing;
        }

        private void getNumberOfSuit()
        {
            foreach (var e in Cards)
            {
                if (e.Suit == Card.SUIT.HEARTS)
                    heartsSum++;
                else if (e.Suit == Card.SUIT.DIAMONDS)
                    diamondSum++;
                else if (e.Suit == Card.SUIT.CLUBS)
                    clubSum++;
                else if (e.Suit == Card.SUIT.SPADES)
                    spadesSum++;
            }
        }

        private bool FourOfAKind()
        {
            //if the first 4 cards, add values of the four cards and last card is the highest
            if(cards[0].Value == cards[1].Value && cards[0].Value == cards[2].Value && cards[0].Value == cards[3].Value)
            {
                handValue.Total = (int)cards[1].Value * 4;
                handValue.HightCard = (int)cards[4].Value;
                return true;
            }
            else if(cards[1].Value == cards[2].Value && cards[1].Value == cards[3].Value && cards[1].Value == cards[4].Value)
            {
                handValue.Total = (int)cards[1].Value * 4;
                handValue.HightCard = (int)cards[1].Value;
                return true;
            }

            return false;
        }

        private bool FullHouse()
        {
            if((cards[0].Value == cards[1].Value && cards[0].Value == cards[2].Value && cards[3].Value == cards[4].Value) 
                ||
               (cards[0].Value == cards[1].Value && cards[2].Value == cards[3].Value && cards[3].Value == cards[4].Value))
            {
                handValue.Total = (int)(cards[0].Value) + (int)(cards[1].Value) + (int)(cards[3].Value) + (int)(cards[4].Value);
                return true;
            }
            return false;
        }

        private bool Flush()
        {
            if(heartsSum == 5 || diamondSum == 5 || clubSum == 5 || spadesSum == 5)
            {
                //if flush, player with highter cards win
                //who ever has the last card the highest, has automatically all the cards total higher
                handValue.Total = (int)cards[4].Value;
                return true;
            }
            return false;
        }

        private bool Straight()
        {
             if(cards[0].Value + 1 == cards[1].Value && cards[1].Value + 1 == cards[2].Value
                &&
                cards[2].Value + 1 == cards[3].Value && cards[3].Value + 1 == cards[4].Value)
            {
                handValue.Total = (int)cards[4].Value;
                return true;
            }
            return false;
        }

        private bool ThreeOfAKind()
        {
            //if 1, 2, 3 cards are the same or 2, 3, 4 cards are teh same or, 3, 4, 5 cards are the same
            //3rd card will always be a part of the three of a kind
            if ((cards[0].Value == cards[1].Value) && (cards[0].Value == cards[2].Value)
                ||
                (cards[1].Value == cards[2].Value) && (cards[1].Value == cards[3].Value))
            {
                handValue.Total = (int)cards[2].Value * 3;
                handValue.HightCard = (int)cards[4].Value;
                return true;
            }           
            else if(cards[2].Value == cards[3].Value && cards[2].Value == cards[4].Value)
            {
                handValue.Total = (int)cards[2].Value * 3;
                handValue.HightCard = (int)cards[1].Value;
                return true;
            }
            return false;
        }

        private bool TwoPairs()
        {
            //if 1, 2 and , 3, 4 or 1, 2 and , 4, 5 or 2, 3, and 4, 5
            if(cards[0].Value == cards[1].Value && cards[2].Value == cards[3].Value)
            {
                handValue.Total = (int)cards[1].Value * 2 + (int)cards[3].Value * 2;
                handValue.HightCard = (int)cards[4].Value; 
                return true;
            }
            else if(cards[0].Value == cards[1].Value && cards[3].Value == cards[4].Value)
            {
                handValue.Total = (int)cards[1].Value * 2 + (int)cards[3].Value * 2;
                handValue.HightCard = (int)cards[2].Value;
                return true;
            }
            else if (cards[1].Value == cards[2].Value && cards[3].Value == cards[4].Value)
            {
                handValue.Total = (int)cards[1].Value * 2 + (int)cards[3].Value * 2;
                handValue.HightCard = (int)cards[1].Value;
                return true;
            }
            return false;
        }

        private bool Pair()
        {
            //if 1, 2 or 2, 3, or 3, 4, or 4, 5
            if(cards[0].Value == cards[1].Value)
            {
                handValue.Total = (int)cards[0].Value * 2;
                handValue.HightCard = (int)cards[4].Value;
                return true;
            }
            else if(cards[1].Value == cards[2].Value)
            {
                handValue.Total = (int)cards[1].Value * 2;
                handValue.HightCard = (int)cards[4].Value;
                return true;
            }
            else if(cards[2].Value == cards[3].Value)
            {
                handValue.Total = (int)cards[2].Value * 2;
                handValue.HightCard = (int)cards[4].Value;
                return true;
            }
            else if(cards[3].Value == cards[4].Value)
            {
                handValue.Total = (int)cards[3].Value * 2;
                handValue.HightCard = (int)cards[2].Value;
                return true;
            }
            return false;
        }
    }
}
