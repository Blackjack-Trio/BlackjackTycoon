﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackjackTycoon.Models
{
    public class Game
    {
        public string Name { get; set; }
        public List<string> Rules { get; set; }
        public string Type { get; set; }
        public ApplicationUser Player { get; set; }

        public Game()
        {
            Name = "";
            Rules = new List<string>();
            Type = "";
            Player = new ApplicationUser();
        }

    }
}
