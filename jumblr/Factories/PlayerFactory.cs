using jumblr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Factories
{
    public class PlayerFactory
    {
        public Player Get(string name)
        {
            return new Player(name);
        }
    }
}
