using jumblr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Factories
{
    public class GameFactory
    {
        public Game Get()
        {
            return new Game(new BoardFactory(), new HandFactory(new TileFactory()));
        }
    }
}
