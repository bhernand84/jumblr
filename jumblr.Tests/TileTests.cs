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

        [Test]
        public void TestRotateTileChangesLetter()
        {
            Tile tile = tileFactory.GetTile();
            var letter = tile.Letter;
            tile.Rotate();
            Assert.AreNotEqual(letter, tile.Letter);
        }
    }
}
