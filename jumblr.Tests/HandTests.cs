using jumblr.Factories;
using jumblr.Models;
using jumblr.Models.Enums;
using NUnit.Framework;
using System;

namespace jumblr.Tests
{
    [TestFixture]
    public class HandTests
    {
        protected HandFactory handFactory = new HandFactory(new TileFactory());

        [Test]
        public void TestHandInitsWithNumberOfTilesSet()
        {
            for (int i = 0; i < 15; i++)
            {
                Hand hand = handFactory.GetHand(i);
                Assert.AreEqual(hand.Length, i);
            }
        }
    }
}
