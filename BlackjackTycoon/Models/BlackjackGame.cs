using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class BlackjackGame : Game
    {
        // props
        private BlackjackDealer dealer;
        private BlackjackPlayer player;
        private int min_bet;
        private int max_bet;
        private int deck_count;

        // constructors
        public BlackjackGame()
        {
            Name = "Blackjack";
            Rules.Add("Get 21 to win!");
            Type = "Card";
        }

        public BlackjackGame(int min_bet, int max_bet, int deck_count)
        {
            this.min_bet = min_bet;
            this.max_bet = max_bet;
            this.deck_count = deck_count;

            try
            {
                this.dealer = new BlackjackDealer();
                this.dealer.JoinGame(this);
            }
            catch (Exception ex)
            {
                throw new Exception('could not create or add dealer to game: ' + ex);
            }

        }

        // class methods
        internal void Play()
        {
            throw new NotImplementedException();
        }
    }
}
