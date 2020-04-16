using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class BlackjackHand
    {
        // props
        public bool Busted { get; set; }
        public bool Standing { get; set; }
        public bool Done { get; set; }
        public bool Blackjack { get; set; }
        public decimal Bet { get; set; }
        public List<Card> Cards { get; set; }

        // constructors
        public BlackjackHand() { }

        public BlackjackHand(decimal bet)
        {
            this.Bet = bet;
        }

        // class methods
        public override string ToString()
        {
            string s = "| ";
            foreach(Card c in this.Cards)
            {
                s += c + " |";
            }
            return s;
        }

        public void Hit(Card card)
        {
            if (this.CanHit())
            {
                Cards.Add(card);
                this.CheckBlackjack();
                this.CheckBusted();
            }
            else
            {
                throw new Exception("Cannot hit on this hand: " + this);
            }
        }

        public bool CanHit()
        {
            bool canHit = true;
            if (this.GetValue() == 21 || this.Blackjack || this.Busted || this.Standing)
            {
                canHit = false;
            }
            return canHit;
        }

        public void Stand()
        {
            this.Standing = true;
            this.Done = true;
        }

        public int GetValue()
        {
            int value = this.GetSoftValue();
            if (value > 21)
            {
                value = this.GetHardValue();
            }
            return value;
        }

        public int GetHardValue()
        {
            int value = 0;
            foreach (Card c in this.Cards)
            {
                value += c.HardValue;
            }
            return value;
        }

        public int GetSoftValue()
        {
            int value = 0;
            foreach (Card c in this.Cards)
            {
                value += c.SoftValue;
            }
            return value;
        }

        public void CheckBlackjack()
        {
            if (this.GetValue() == 21 && this.Cards.Count == 2)
            {
                this.Blackjack = true;
                this.Done = true;
            }
        }

        public void CheckBusted()
        {
            if (this.GetValue() > 21)
            {
                this.Busted = true;
                this.Done = true;
            }
        }

        public bool CanStand()
        {
            if (this.Done)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
