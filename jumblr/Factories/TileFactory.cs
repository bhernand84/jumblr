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

        protected string vowels;
        protected string consonants;
        protected Random rand = new Random();

        protected string[] GetRandomLetters()
        {
            vowels = Alphabet.Vowels;
            consonants = Alphabet.Consonants;

            string[] toReturn = new string[6];
            
            int[] vowelIndices = new int[2];
            vowelIndices[0] = rand.Next(0,6);
            do
            {
                vowelIndices[1] = rand.Next(0, 6);
            } while (vowelIndices[1] == vowelIndices[0]);

            for (int i = 0; i < 6; i++)
            {
                if (vowelIndices.Contains(i)) {
                    toReturn[i] = GetRandomLetterFromArray(vowels);
                    vowels = vowels.Remove(vowels.IndexOf(toReturn[i]),1);
                }
                else
                {
                    toReturn[i] = GetRandomLetterFromArray(consonants);
                    consonants = consonants.Remove(consonants.IndexOf(toReturn[i]),1);
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
