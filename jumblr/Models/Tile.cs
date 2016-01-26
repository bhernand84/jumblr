using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Models
{
    public class Tile
    {
        #region Fields
        protected int activeIndex { get; set; }
        protected string[] letters { get; set; }
        #endregion

        #region Properties

        public string Letter { get { return letters[activeIndex]; } }
        
        #endregion

        #region Methods

        public void Rotate() {
            activeIndex++;
        }
        
        #endregion

        #region Constructors

        public Tile() { }

        public Tile(string[] letters)
        {
            this.letters = letters;
        }

        #endregion
    }
}
