using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jumblr.Factories;

namespace jumblr.Models
{
    public class Game
    {
        #region Properties
        public Player Player { get; set; }
        public Board Board { get; set; }

        protected BoardFactory boardFactory { get; set; }
        protected HandFactory handFactory {get;set;}
        protected int handSize = 12;
        protected int boardSize = 24;
        #endregion

        #region Constructors

        public Game(BoardFactory boardFactory, HandFactory handFactory) {
            this.boardFactory = boardFactory;
            this.handFactory = handFactory;
        }
        #endregion

        #region Methods
        public void Join(Player player)
        {
            Player = player;
        }

        public void Start()
        {
            Player.Hand = handFactory.GetHand(handSize);
            Board = boardFactory.Get(boardSize);
        }

        public void Place(Tile tile, int x, int y)
        {
            if (Player.Hand.Contains(tile)) {
                Board.Place(tile, x, y);
                Player.Hand.Remove(tile);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        #endregion
    }
}
