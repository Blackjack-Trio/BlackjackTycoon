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

        public bool Play(string selection, int bet)
        {
            /* variables */
            bool result = false;
            /* Generate either 0 or 1 randomly */
            Random random = new Random();
            var n = random.Next(0, 2);

            /* take the bet amount from the players bankroll */
            this.Player.Bankroll -= bet;
  
            /* Check if player won */
            if (selection == "heads" && n == 1 || selection == "tails" && n == 0)
            {
                result = true;
                Payout(bet);
            }

            return result;
        }

        private void Payout(int bet)
        {
            this.Player.Bankroll += bet * 2;
        }
    }
}
