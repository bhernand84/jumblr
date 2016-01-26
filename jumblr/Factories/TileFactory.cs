using jumblr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Factories
{
    public class TileFactory
    {
        public Tile GetTile()
        {
            Tile tile =new Tile(new string[]{"a","b","c","d","e","f"});
            return tile;
        }
    }
}
