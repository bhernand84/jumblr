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
    public class BoardTests
    {
        protected BoardFactory boardFactory = new BoardFactory();
        protected HandFactory handFactory = new HandFactory(new TileFactory());

        [Test]
        public void TestBoardIsCreatedInASquare()
        {
            Board board = boardFactory.Get(15);
            Assert.AreEqual(board.Columns, 15);
            Assert.AreEqual(board.Rows, 15);
        }

        [Test]
        public void TestWhenBoardInitsAllSpacesAreEmpty()
        {
            Board board = boardFactory.Get(15);
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Assert.True(board.IsEmpty(i,j));
                }
            }
        }

        [Test]
        public void TestTileCanBePlacedOnEmptySpace()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            board.Place(hand.First(), 1, 1);
            Assert.False(board.IsEmpty(1, 1));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestTilePlacedOnTakenSpaceThrowsException()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            board.Place(hand.First(), 1, 1);
            Assert.False(board.IsEmpty(1, 1));
            board.Place(hand.First(), 1, 1);
        }

        [Test]
        public void TilesPlacedAdjacentVerticallyFormWords()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            var word = hand.First().Letter + hand.Skip(1).First().Letter;
            board.Place(hand.First(), 1, 1);
            board.Place(hand.Skip(1).First(), 1, 2);

            var words = board.GetWords();
            Assert.AreEqual(words.Count(), 1);
            Assert.AreEqual(words.First(), word);
        }

    }
}
