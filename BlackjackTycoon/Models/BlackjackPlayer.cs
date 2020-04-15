using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class BlackjackPlayer
    {
        // props
        private ApplicationUser user;
        private BlackjackHand hand;
        private Game game;

        // constructors
        public BlackjackPlayer() { }

        public BlackjackPlayer(ApplicationUser user)
        {
            this.user = user;
        }

        // class methods
        public BlackjackHand getHand()
        {
            return this.hand;
        }

        public void JoinGame(Game game)
        {
            if (this.game == null)
            {
                this.game = game;
            }
            else
            {
                throw new Exception("Player cannot join a new game before leaving previous game.");
            }
        }

        public void LeaveGame()
        {
            this.game = null;
        }

        public void Bet(int amount)
        {
            if (game == null) throw new Exception("Player cannot bet if they are not part of a game.");
            if (this.user.Bankroll < amount) throw new Exception("Player cannot bet more than they have.");

            // take bet amount from players bankroll.
            this.user.Bankroll -= amount;
        }

        public bool ShouldStandWith(BlackjackHand hand)
        {
            bool should = false;

            if (hand.getValue() >= 16)
            {
                should = true;
            }

            return should;
        }
    }
}
