using Microsoft.VisualStudio.TestTools.UnitTesting;
using CraftyPucker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Tests
{
    [TestClass()]
    public class GameTests
    {

        [TestMethod()]
        public void MediaFeedParentGameIsSet()
        {
            var game = (new GameBuilder())
                .WithHomeTeam()
                .WithHomeMediaFeed()
                .HomeGame()
                .Build();

            var setMediaFeedCount = game.MediaFeeds.Values.Count(x => x.ParentGame == game);

            Assert.AreEqual(setMediaFeedCount, game.MediaFeeds.Count());

        }
        
        [TestMethod()]
        public void IsLive_Works()
        {
            var g = new Game();
            g.Date = DateTime.Now.AddHours(-6);
            Assert.IsTrue(g.IsLive);
        }

    }
}