﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class BlackjackPlayer
    {
        // props
        public ApplicationUser User { get; set; }
        public BlackjackHand Hand { get; set; }
        public Game Game { get; set; }

        // constructors
        public BlackjackPlayer() { }

        public BlackjackPlayer(ApplicationUser user)
        {
            this.User = user;
        }

        // class methods
        public BlackjackHand getHand()
        {
            return this.Hand;
        }

        public void JoinGame(Game game)
        {
            if (this.Game == null)
            {
                this.Game = game;
            }
            else
            {
                throw new Exception("Player cannot join a new game before leaving previous game.");
            }
        }

        public void LeaveGame()
        {
            this.Game = null;
        }

        public void Bet(decimal amount)
        {
            if (Game == null) throw new Exception("Player cannot bet if they are not part of a game.");
            if (this.User.Bankroll < amount) throw new Exception("Player cannot bet more than they have.");

            // take bet amount from players bankroll.
            this.User.Bankroll -= amount;
        }

        public bool ShouldStandWith(BlackjackHand hand)
        {
            bool should = false;

            if (hand.GetValue() >= 16)
            {
                should = true;
            }

            return should;
        }
    }
}
