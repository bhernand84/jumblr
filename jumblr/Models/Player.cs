﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Hand Hand { get; set; }

        public Player() { }
        public Player(string name)
        {
            Name = name;
        }
    }
}
