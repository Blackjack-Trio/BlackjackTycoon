using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class Player
    {
        public ApplicationUser User { get; set; }
        public decimal Pocket { get; set; }

        public Player(ApplicationUser user, decimal pocket)
        {
            User = user;
            Pocket = pocket;
        }
    }
}
