using jumblr.Models.Enums;
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

        public void Rotate(Direction direction = Direction.Right) {
            switch (direction){
                case Direction.Down:
                    letters = new string[] { letters[1], letters[5], letters[0], letters[3], letters[4], letters[2] };
                    break;
                case Direction.Up:
                    letters = new string[] { letters[2], letters[0], letters[5], letters[3], letters[4], letters[1] };
                    break;
                case Direction.Left:
                    letters = new string[] { letters[4], letters[1], letters[2], letters[0], letters[5], letters[3] };
                    break;
                case Direction.Right:
                    letters = new string[] { letters[3], letters[1], letters[2], letters[5], letters[0], letters[4] };
                    break;
                default:
                    activeIndex++;
                    break;
            }
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
