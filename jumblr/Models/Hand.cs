using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Models
{
    public class Hand : IEnumerable<Tile>
    {
        #region Fields

        protected IEnumerable<Tile> tiles;

        #endregion

        #region Properties
        
        public int Length { get { return tiles.Count(); } }
        
        #endregion

        #region Constructors 

        public Hand(IEnumerable<Tile> tiles)
        {
            this.tiles = tiles;
        }

        #endregion

        #region IEnumerable<Tile> Implementation

        public IEnumerator<Tile> GetEnumerator()
        {
            return tiles.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return tiles.GetEnumerator();
        }

        #endregion
    }
}
