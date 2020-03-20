using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class Deck
    {
        private static readonly Random Random = new Random(); // This guarantees more random numbers. Trust me.
        public List<Card> Cards { get; set; }

        public Deck(int deckCount=1)
        {
            int decksCreated = 0;
            while (deckCount > decksCreated)
            {
                // Cycle through all the suits
                foreach (string suit in Card.Suits.Values)
                {
                    // Cycle through all the ranks
                    foreach (string rank in Card.Ranks.Values)
                    {
                        // Create a card with the cycled suit/rank and add it to the deck's cards
                        Card newCard = new Card(rank, suit);
                        Cards.Add(newCard);
                    }
                }
                decksCreated++;
            }
        }

        public void Shuffle()
        {
            // I found this code from here: https://stackoverflow.com/questions/5383498/shuffle-rearrange-randomly-a-liststring
            // Not entirely sure how it works but it does
            Cards.OrderBy(item => Random.Next());
        }

        public Card Draw(int cardCount=1, bool faceUp=false)
        {
            if (Cards.Count >= 1)
            {
                // Grabbing the first card the deck's card list, returning it, and destroying it from the deck
                Card drawnCard = Cards[0];
                Cards.RemoveAt(0);
                return drawnCard;
            } else
            {
                throw new Exception("No cards left to draw!");
            }
        }

        
    }
}
