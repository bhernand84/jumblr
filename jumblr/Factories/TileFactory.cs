using jumblr.Models;
using jumblr.Resources;
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
            Tile tile =new Tile(GetRandomLetters());
            return tile;
        }

        protected string vowels = Alphabet.Vowels;
        protected string consonants = Alphabet.Consonants;
        protected Random rand = new Random();

        protected string[] GetRandomLetters()
        {
            string[] toReturn = new string[6];
            
            for (int i = 0; i < 6; i++)
            {
                if (i < 2) {
                    toReturn[i] = GetRandomLetterFromArray(vowels);
                }
                else
                {
                    toReturn[i] = GetRandomLetterFromArray(consonants);
                }
                
            }
            return toReturn;
        }

        protected string GetRandomLetterFromArray(string start)
        {
            return start[rand.Next(0, start.Length)].ToString();
        }
    }
}
