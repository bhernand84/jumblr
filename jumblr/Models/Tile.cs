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
                    letters = new string[] { letters[(int)TilePosition.Top], letters[(int)TilePosition.Opposite], letters[(int)TilePosition.Center], letters[(int)TilePosition.Left], letters[(int)TilePosition.Right], letters[(int)TilePosition.Bottom]};
                    break;
                case Direction.Up:
                    letters = new string[] { letters[(int)TilePosition.Bottom], letters[(int)TilePosition.Center], letters[(int)TilePosition.Opposite], letters[(int)TilePosition.Left], letters[(int)TilePosition.Right], letters[(int)TilePosition.Top] };
                    break;
                case Direction.Left:
                    letters = new string[] { letters[(int)TilePosition.Right], letters[(int)TilePosition.Top], letters[(int)TilePosition.Bottom], letters[(int)TilePosition.Center], letters[(int)TilePosition.Opposite], letters[(int)TilePosition.Left] };
                    break;
                case Direction.Right:
                    letters = new string[] { letters[(int)TilePosition.Left], letters[(int)TilePosition.Top], letters[(int)TilePosition.Bottom], letters[(int)TilePosition.Opposite], letters[(int)TilePosition.Center], letters[(int)TilePosition.Right] };
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
