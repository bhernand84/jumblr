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
        protected List<string> Words { get; set; }
        public int Rows { get { return Spaces.GetLength(1); } }
        public int Columns { get{ return Spaces.GetLength(0);} }

        #region Methods

        public bool IsEmpty(int x, int y)
        {
            return Spaces[x,y] == null;
        }
        
        public void Place(Tile tile, int p1, int p2)
        {
            if (IsEmpty(p1, p2))
            {
                Spaces[p1, p2] = tile;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<string> GetWords()
        {
            string verticalWord = null;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (!IsEmpty(i, j))
                    {
                        verticalWord += Spaces[i, j].Letter;
                    }
                    else
                    {
                        if (verticalWord.IsValid())
                        {
                            Words.Add(verticalWord);
                        }
                        verticalWord = null;
                    }
                }
            }
            return Words;
        }
             
        #endregion

        public Board(int size)
        {
           Spaces = new Tile[size,size];
           Words = new List<string>();
        }

      
    }

    public static class Helpers{
      public static bool IsValid(this string input)
        {
            return input != null && input.Length > 1;

        }
    }
}
