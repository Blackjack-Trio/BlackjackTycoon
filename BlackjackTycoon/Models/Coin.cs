using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class Coin
    {
        private static readonly Random rnd = new Random();

        public bool Face { get; set; }
        
        public Coin(string face="heads")
        {
            if (face.Equals("heads"))
            {
                Face = true;
            } else
            {
                Face = false;
            }
        }

        public bool Flip()
        {
            bool result = Convert.ToBoolean(rnd.Next(0, 1));
            Face = result;
            return result;
        }

        public override string ToString()
        {
            if (Face)
            {
                return "Heads";
            } else
            {
                return "Tails";
            }
        }
    }
}
