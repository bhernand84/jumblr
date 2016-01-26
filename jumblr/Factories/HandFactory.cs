using jumblr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Factories
{
    public class HandFactory 
    {
        protected TileFactory tileFactory;

        public Hand GetHand(int handSize)
        {
            List<Tile> tiles = new List<Tile>();
            for (int i = 0; i < handSize; i++)
            {
                tiles.Add(tileFactory.GetTile());
            }
            return new Hand(tiles);
        }

        public HandFactory(TileFactory tileFactory)
        {
            this.tileFactory = tileFactory;
        }
    }
}
