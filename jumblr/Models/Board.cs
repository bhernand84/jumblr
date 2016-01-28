using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Models
{
    public class Board
    {
        public Tile[,] Spaces { get; private set; }

        public int Rows { get { return Spaces.GetLength(1); } }
        public int Columns { get{ return Spaces.GetLength(0);} }

        #region Methods

        public bool IsEmpty(int x, int y)
        {
            return Spaces[x,y] == null;
        }

        #endregion
        public Board(int size)
        {
           Spaces = new Tile[size,size];
        }
    }
}
