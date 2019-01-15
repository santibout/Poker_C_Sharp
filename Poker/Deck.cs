using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Deck : Card
    {
        public Card[] GetDeck { get { return deck; } }

        const int NUM_OF_CARDS = 52;
        private Card[] deck;

        public Deck()
        {
            deck = new Card[NUM_OF_CARDS];
        }

        public void CreateDeck()
        {
            int i = 0;
            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach(VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card { Suit = s, Value = v }; 
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            Random r = new Random();
            Card temp;

            //run shuffle 1000 times
            for (int shuffleAmmound = 0; shuffleAmmound < 1000; shuffleAmmound++)
            {
                for(int i = 0; i < NUM_OF_CARDS; i++)
                {
                    int secondCardIndex = r.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }
    }
}
