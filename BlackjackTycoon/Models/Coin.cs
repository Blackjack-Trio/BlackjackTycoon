using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class Coin
    {
        public bool Face { get; set; }
        
        public Coin()
        {

        }

        public bool Flip()
        {
            bool result = Convert.ToBoolean(new Random().Next(0, 1));
            Face = result;
            return result;
        }
    }
}
