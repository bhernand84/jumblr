using jumblr.Factories;
using jumblr.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jumblr.Tests
{
    [TestFixture]
    public class GameTests
    {
        GameFactory gameFactory = new GameFactory();
        PlayerFactory playerFactory =new PlayerFactory();

        [Test]
        public void TestPlayerCanJoinGame()
        {
            Game game = gameFactory.Get();
            var player= playerFactory.Get("Ben");
            game.Join(player);
            Assert.AreEqual(game.Player, player);
        }

        [Test]
        public void TestPlayerStartsGameWithHandAndBoard()
        {
            Game game = gameFactory.Get();
            var player = playerFactory.Get("Ben");
            game.Join(player);
            game.Start();
            Assert.IsNotNull(game.Board);
            Assert.IsNotNull(game.Player.Hand);
        }

        [Test]
        public void TestPlayerCanPlaceTileFromHandToBoard()
        {
            Game game = gameFactory.Get();
            var player = playerFactory.Get("Ben");
            game.Join(player);
            game.Start();

            int handSize = game.Player.Hand.Length;
            game.Place(game.Player.Hand.First(), 1, 1);

            Assert.False(game.Board.IsEmpty(1, 1));
            Assert.AreEqual(handSize - 1, game.Player.Hand.Length);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPlayerCannotPlaceTileNotInHandToBoard()
        {
            Game game = gameFactory.Get();
            var player = playerFactory.Get("Ben");
            game.Join(player);
            game.Start();

            int handSize = game.Player.Hand.Length;
            game.Place(new Tile(), 1, 1);
        }
    }
}
