using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class CoinflipGame:Game
    {

        public CoinflipGame()
        {
            Name = "Coinflip";
            Rules.Add("You must pick a side.");
            Type = "Coin";
        }

        
    }
}
