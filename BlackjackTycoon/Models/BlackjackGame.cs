using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class BlackjackGame:Game
    {

        public BlackjackGame()
        {
            Name = "Blackjack";
            Rules.Add("Get 21 to win!");
            Type = "Card";
        }
    }
}
