using jumblr.Factories;
using jumblr.Models;
using jumblr.Models.Enums;
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

        [Test]
        public void TestTileCanRotateDownThenBackUpToOriginalLetter()
        {
            Tile tile = tileFactory.GetTile();

            var letter = tile.Letter;            
            tile.Rotate(Direction.Up);
            var rotatedLetter = tile.Letter;
            tile.Rotate(Direction.Down);

            Assert.AreNotEqual(letter, rotatedLetter);
            Assert.AreNotEqual(tile.Letter, rotatedLetter);
            Assert.AreEqual(letter, tile.Letter);
        }

        [Test]
        public void TestTileCanRotateLeftThenBackRightToOriginalLetter()
        {
            Tile tile = tileFactory.GetTile();

            var letter = tile.Letter;
            tile.Rotate(Direction.Left);
            var rotatedLetter = tile.Letter;
            tile.Rotate(Direction.Right);

            Assert.AreNotEqual(letter, rotatedLetter);
            Assert.AreNotEqual(tile.Letter, rotatedLetter);
            Assert.AreEqual(letter, tile.Letter);
        }
    }
}
