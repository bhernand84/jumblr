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


    }
}
