using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Models
{
    public class Game
    {
        #region Properties
        public Player Player { get; set; }
        #endregion

        #region Constructors

        public Game() { }
        #endregion

        #region Methods
        public void Join(Player player)
        {
            Player = player;
        }
        #endregion
    }
}
