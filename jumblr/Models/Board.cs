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
            string horizontalWord = null;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    verticalWord = checkTile(i, j, verticalWord);
                    horizontalWord = checkTile(j, i, horizontalWord);
                }
                AddWord(verticalWord);
                AddWord(horizontalWord);
                verticalWord = horizontalWord = null;
            }

            return Words;
        }
        protected string checkTile(int x, int y, string word)
        {
            if (!IsEmpty(x, y))
            {
                word += Spaces[x, y].Letter;
            }
            else
            {
                AddWord(word);
                word = null;
            }
            return word;
        }

        protected void AddWord(string word)
        {
            if (word.IsValid())
            {
                Words.Add(word);
            }
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
