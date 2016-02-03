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

    }
}
