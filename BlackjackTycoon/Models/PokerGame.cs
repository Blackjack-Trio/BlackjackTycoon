using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class PokerGame:Game
    {
        public PokerGame()
        {
            Name = "Poker";
            Rules.Add("Texas hold'em poker");
            Type = "Card";
        }
    }
}
