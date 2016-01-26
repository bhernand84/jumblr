using jumblr.Factories;
using jumblr.Models;
using NUnit.Framework;
using System;

namespace jumblr.Tests
{
    [TestFixture]
    public class TileTests
    {
        protected TileFactory tileFactory = new TileFactory();

        [Test]
        public void TestTileHasActiveLetter()
        {
            Tile tile = tileFactory.GetTile();
            Assert.NotNull(tile.Letter);
        }
    }
}
