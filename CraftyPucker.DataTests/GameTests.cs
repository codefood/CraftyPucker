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
        [ExpectedException(typeof(NullReferenceException))]
        public void ThrowsNullWithNoHomeTeam()
        {
            var game = (new GameBuilder())
                .WithAwayTeam()
                .WithHomeMediaFeed()
                .HomeGame()
                .Build();
            var url = game.GetUriForMediaFeed(StreamType.Live, game.MediaFeeds.First());
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void ThrowsNullWithNoAwayTeam()
        {
            var game = (new GameBuilder())
                .WithHomeTeam()
                .WithHomeMediaFeed()
                .HomeGame()
                .Build();
            var url = game.GetUriForMediaFeed(StreamType.Live, game.MediaFeeds.First());
        }

        [TestMethod()]
        public void HomeGame_LiveStream()
        {
            var game = (new GameBuilder())
                .WithHomeTeam()
                .WithAwayTeam()
                .WithHomeMediaFeed()
                .HomeGame()
                .Build();
            var url = game.GetUriForMediaFeed(StreamType.Live, game.MediaFeeds.First());

            Assert.AreEqual(url, "http://hlslive-cdn.med2.med.nhl.com/ls04/nhl/2016/03/13/NHL_GAME_VIDEO_CHIDET_M2_HOME_2016/03/13/master_wired60.m3u8");

        }

        [TestMethod()]
        public void AwayGame_LiveStream()
        {
            var game = (new GameBuilder())
                .WithHomeTeam()
                .WithAwayTeam()
                .WithAwayMediaFeed()
                .AwayGame()
                .Build();
            var url = game.GetUriForMediaFeed(StreamType.Live, game.MediaFeeds.First());

            Assert.AreEqual(url, "http://hlslive-cdn.med2.med.nhl.com/ls04/nhl/2016/03/13/NHL_GAME_VIDEO_CHIDET_M2_VISIT_2016/03/13/master_wired60.m3u8");

        }

        [TestMethod()]
        public void HomeGame_VODStream()
        {
            var game = (new GameBuilder())
                .WithHomeTeam()
                .WithAwayTeam()
                .WithHomeMediaFeed()
                .HomeGame()
                .Build();
            var url = game.GetUriForMediaFeed(StreamType.VOD, game.MediaFeeds.First());

            Assert.AreEqual(url, "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl//2016/03/13/NHL_GAME_VIDEO_CHIDET_M2_HOME_2016/03/13/master_wired60.m3u8");

        }

        [TestMethod()]
        public void AwayGame_VODStream()
        {
            var game = (new GameBuilder())
                .WithHomeTeam()
                .WithAwayTeam()
                .WithAwayMediaFeed()
                .AwayGame()
                .Build();
            var url = game.GetUriForMediaFeed(StreamType.VOD, game.MediaFeeds.First());

            Assert.AreEqual(url, "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl//2016/03/13/NHL_GAME_VIDEO_CHIDET_M2_VISIT_2016/03/13/master_wired60.m3u8");

        }

    }
}