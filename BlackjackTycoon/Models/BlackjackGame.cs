using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class BlackjackGame : Game
    {
        // props
        public BlackjackDealer Dealer { get; set; }
        public BlackjackPlayer Player { get; set; }
        public decimal MinBet { get; set; }
        public decimal MaxBet { get; set; }
        public int DeckCount { get; set; }

        // constructors
        public BlackjackGame()
        {
            Name = "Blackjack";
            Rules.Add("Get 21 to win!");
            Type = "Card";
        }

        public BlackjackGame(decimal min_bet, decimal max_bet, int deck_count)
        {
            this.MinBet = min_bet;
            this.MaxBet = max_bet;
            this.DeckCount = deck_count;

            try
            {
                this.Dealer = new BlackjackDealer();
                this.Dealer.JoinGame(this);
            }
            catch (Exception ex)
            {
                throw new Exception("could not create or add dealer to game: " + ex);
            }

        }
    }
}
