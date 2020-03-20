using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class Card
    {
        // These large dictionaries are simply used to list out all the possible titles and values this card could be.
        // The Ranks and Suits are static because we want to be able to access these things without making a card instance.

        public static Dictionary<string, string> Ranks = new Dictionary<string, string>()
        {
            {"ace", "Ace"},
            {"two", "Two"},
            {"three", "Three"},
            {"four", "Four"},
            {"five", "Five"},
            {"six", "Six"},
            {"seven", "Seven"},
            {"eight", "Eight"},
            {"nine", "Nine"},
            {"ten", "Ten"},
            {"jack", "Jack"},
            {"queen", "Queen"},
            {"king", "King"}
        };

        public static Dictionary<string, string> Suits = new Dictionary<string, string>()
        {
            {"hearts", "Hearts"},
            {"diamonds", "Diamonds"},
            {"spades", "Spades"},
            {"clubs", "Clubs"}
        };

        private readonly Dictionary<string, int> HardValues = new Dictionary<string, int>()
        {
            {"ace", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"ten", 10},
            {"jack", 10},
            {"queen", 10},
            {"king", 10}
        };

        private readonly Dictionary<string, int> SoftValues = new Dictionary<string, int>()
        {
            {"ace", 11},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"ten", 10},
            {"jack", 10},
            {"queen", 10},
            {"king", 10}
        };

        public string Rank { get; set; }
        public string Suit { get; set; }
        public int SoftValue { get; set; }
        public int HardValue { get; set; }
        public bool IsShowing { get; set; }
        public bool IsAce { get; set; }
        public bool IsFace { get; set; }

        public Card(string rank, string suit, bool showing=false)
        {
            // Normalizing input...
            rank = rank.ToLower();
            suit = rank.ToLower();

            // Validating rank...
            if (Ranks.ContainsKey(rank))
            {
                Rank = Ranks[rank];
            } else
            {
                throw new Exception("Invalid card rank: " + rank);
            }

            // Validating suit...
            if (Suits.ContainsKey(suit))
            {
                Suit = Suits[suit];
            } else
            {
                throw new Exception("Invalid card suit: " + suit);
            }

            // Setting hard/soft values...
            HardValue = HardValues[rank];
            SoftValue = SoftValues[rank];

            // Is it a special card of some kind?
            if (rank.Equals("ace"))
            {
                IsAce = true;
            } else if (rank.Equals("jack") || rank.Equals("queen") || rank.Equals("king"))
            {
                IsFace = true;
            }

            // Will the card's value be showing?
            IsShowing = showing;
        }
    }
}
