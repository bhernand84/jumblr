using jumblr.Factories;
using jumblr.Models;
using jumblr.Models.Enums;
using jumblr.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [Test]
        public void TestTileRotatesFourTimesInSameDirectionIsBackToOriginalState()
        {
            Tile tile = tileFactory.GetTile();

            for (int i = 0; i < 4; i++)
            {
                Direction toRotate = (Direction)i;
                var letter = tile.Letter;
                tile.Rotate(toRotate);
                tile.Rotate(toRotate);
                tile.Rotate(toRotate);
                tile.Rotate(toRotate);
                Assert.AreEqual(letter, tile.Letter);
            }
        }

        [Test]
        public void TestTilesAreRandomlyGenerated()
        {
            Tile tile = tileFactory.GetTile();
            Tile tile2 = tileFactory.GetTile();

            Assert.AreNotEqual(tile.Letters, tile2.Letters);
        }
        
        [Test]
        public void TestTilesMayNotHaveMoreThan2Vowels()
        {
            for (int i = 0; i < 15; i++)
            {
                Tile tile = tileFactory.GetTile();
                Assert.GreaterOrEqual(tile.Letters.Count(m=> Alphabet.Vowels.Contains(m)),2);
            }
        }

        [Test]
        public void TestTilesMustHaveAtLeast4Consonants()
        {
            for (int i = 0; i < 15; i++)
            {
                Tile tile = tileFactory.GetTile();
                Assert.GreaterOrEqual(tile.Letters.Count(m => Alphabet.Consonants.Contains(m)), 4);
            }
        }

        [Test]
        public void TestVowelsAreNotAlwaysInSamePosition()
        {
            int firstVowelIndex =0;
            for (int i = 0; i < 15; i++)
            {
                Tile tile = tileFactory.GetTile();
                firstVowelIndex += tile.Letters.ToList().IndexOf(tile.Letters.First(m => Alphabet.Vowels.Contains(m)));
            }
            Assert.GreaterOrEqual(firstVowelIndex, 15);
        }

        [Test]
        public void TestTileCannotRepeatLetters()
        {
            for (int i = 0; i < 15; i++)
            {
                Tile tile = tileFactory.GetTile();
                Assert.AreNotEqual(true, tile.Letters.GroupBy(m=>m).Any(m=>m.Count()>1));

            }
        }
    }
}
