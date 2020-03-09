using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class CoinflipGame:Game
    {
        public int ID { get; set; }    
        public decimal betAmount { get; set; }
        private Player player { get; set; }
        public decimal payOut { get; set; }
        private bool result { get; set; }

        
    }
}
