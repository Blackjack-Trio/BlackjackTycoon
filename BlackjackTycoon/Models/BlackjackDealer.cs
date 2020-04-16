using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class BlackjackDealer : BlackjackPlayer
    {
        // props
        public Deck Deck { get; set; }

        // constructors
        public BlackjackDealer() { }

        public BlackjackDealer(int deck_count = 6)
        {
            try
            {
                this.Deck = new Deck(deck_count);
                this.Deck.Shuffle();
                BlackjackHand newHand = new BlackjackHand(0);
                Card shownCard = this.Deal();
                newHand.Hit(shownCard);
                Card hiddenCard = this.Deal(true);
                newHand.Hit(hiddenCard);
                this.Hand = newHand;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not create dealer: " + ex);
            }
        }

        // class methods
        public override string ToString()
        {
            return this.User.Name;
        }

        public Card Deal(bool asHidden = false)
        {
            Card card = new Card();

            if (this.Deck.Cards.Count < 1)
            {
                this.Deck = new Deck();
                this.Deck.Shuffle();
            }

            if (asHidden)
            {
                card = this.Deck.Draw();
            }
            else
            {
                card = this.Deck.Draw();
                card.IsShowing = true;
            }

            return card;
        }

        public void Shuffle()
        {
            this.Deck.Shuffle();
        }

        // dealer stands on 17
        public bool ShouldStand()
        {
            bool should = false;

            if (this.Hand.GetValue() >= 17)
                should = true;

            return should;
        }

        public bool ShouldShuffle(int playerCount)
        {
            if (this.Deck.Cards.Count < (playerCount * 8))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Payout(BlackjackPlayer player)
        {
            BlackjackHand dealerHand = this.Hand;
            BlackjackHand playerHand = this.Hand;
            decimal winnings = 0;

            if (playerHand.Busted)
            {
                winnings = 0;
            }
            else if (playerHand.Blackjack)
            {
                winnings = playerHand.Bet * 2.5m;
            }
            else if (dealerHand.GetValue() == playerHand.GetValue())
            {
                winnings = playerHand.Bet;
            }
            else if (dealerHand.Busted || dealerHand.GetValue() < playerHand.GetValue())
            {
                winnings = playerHand.Bet * 2m;
            }

            player.User.Bankroll += winnings;
        }

        public BlackjackHand GetHand()
        {
            return this.Hand;
        }

    }
}
