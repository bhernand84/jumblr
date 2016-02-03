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

        [Test]
        public void TilesPlacedAdjacentVerticallyEdgeOfBoardFormWords()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            var word = hand.First().Letter + hand.Skip(1).First().Letter;
            board.Place(hand.First(), 0, 0);
            board.Place(hand.Skip(1).First(), 0, 1);

            board.Place(hand.First(), 14, 13);
            board.Place(hand.Skip(1).First(), 14,14);

            var words = board.GetWords();
            Assert.AreEqual(words.Count(), 2);
            Assert.AreEqual(words.First(), word);
            Assert.AreEqual(words.Skip(1).First(), word);
        }
       
        [Test]
        public void TilesPlacedAdjacentVerticallyEdgeOfBoardDoNotBleedIntoNextRow()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            var word = hand.First().Letter + hand.Skip(1).First().Letter;
            board.Place(hand.First(), 0, 14);
            board.Place(hand.Skip(1).First(), 1, 1);

            board.Place(hand.First(), 14, 13);

            var words = board.GetWords();
            Assert.AreEqual(words.Count(), 0);
        }


        [Test]
        public void MultipleTilesPlacedAdjacentVerticallyFormWords()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            var word = hand.First().Letter + hand.Skip(1).First().Letter;
            var word2 = hand.Skip(1).First().Letter + hand.Skip(2).First().Letter + hand.Skip(3).First().Letter;
            board.Place(hand.First(), 1, 1);
            board.Place(hand.Skip(1).First(), 1, 2);

            board.Place(hand.Skip(1).First(), 3, 2);
            board.Place(hand.Skip(2).First(), 3, 3);
            board.Place(hand.Skip(3).First(), 3, 4);

            var words = board.GetWords();
            Assert.AreEqual(words.Count(), 2);
            Assert.AreEqual(words.First(), word);

            Assert.AreEqual(words.Skip(1).First(), word2);
        }

        [Test]
        public void TilesPlacedAdjacentHorizontallyFormWords()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            var word = hand.First().Letter + hand.Skip(1).First().Letter;
            board.Place(hand.First(), 1, 1);
            board.Place(hand.Skip(1).First(), 2, 1);

            var words = board.GetWords();
            Assert.AreEqual(words.Count(), 1);
            Assert.AreEqual(words.First(), word);
        }

        [Test]
        public void TilesPlacedAdjacentHoriontallyEdgeOfBoardFormWords()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            var word = hand.First().Letter + hand.Skip(1).First().Letter;
            board.Place(hand.First(), 0, 0);
            board.Place(hand.Skip(1).First(), 1, 0);

            board.Place(hand.First(), 13, 14);
            board.Place(hand.Skip(1).First(), 14, 14);

            var words = board.GetWords();
            Assert.AreEqual(words.Count(), 2);
            Assert.AreEqual(words.First(), word);
            Assert.AreEqual(words.Skip(1).First(), word);
        }

        [Test]
        public void TilesPlacedAdjacentHorizontallyEdgeOfBoardDoNotBleedIntoNextRow()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            var word = hand.First().Letter + hand.Skip(1).First().Letter;
            board.Place(hand.First(), 0, 14);
            board.Place(hand.Skip(1).First(), 1, 0);

            board.Place(hand.First(), 13, 14);
            board.Place(hand.First(), 14, 0);

            var words = board.GetWords();
            Assert.AreEqual(words.Count(), 0);
        }


        [Test]
        public void MultipleTilesPlacedAdjacentHorizontallyFormWords()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            var word = hand.First().Letter + hand.Skip(1).First().Letter;
            var word2 = hand.Skip(1).First().Letter + hand.Skip(2).First().Letter + hand.Skip(3).First().Letter;
            board.Place(hand.First(), 1, 1);
            board.Place(hand.Skip(1).First(), 2,  1);

            board.Place(hand.Skip(1).First(), 3, 3);
            board.Place(hand.Skip(2).First(), 4, 3);
            board.Place(hand.Skip(3).First(), 5, 3);

            var words = board.GetWords();
            Assert.AreEqual(words.Count(), 2);
            Assert.AreEqual(words.First(), word);

            Assert.AreEqual(words.Skip(1).First(), word2);
        }

        [Test]
        public void MultipleTilesPlacedAdjacentFormWords()
        {
            Board board = boardFactory.Get(15);
            var hand = handFactory.GetHand(7);
            var word = hand.First().Letter + hand.Skip(1).First().Letter;
            var word2 = hand.Skip(1).First().Letter +  hand.Skip(1).First().Letter + hand.Skip(2).First().Letter + hand.Skip(3).First().Letter;
            board.Place(hand.First(), 1, 1);
            board.Place(hand.Skip(1).First(), 2, 1);

            board.Place(hand.Skip(1).First(), 2, 2);
            board.Place(hand.Skip(2).First(), 2, 3);
            board.Place(hand.Skip(3).First(), 2, 4);

            var words = board.GetWords();
            Assert.AreEqual(words.Count(), 2);
            Assert.AreEqual(words.First(), word);

            Assert.AreEqual(words.Skip(1).First(), word2);
        }
    }
}
