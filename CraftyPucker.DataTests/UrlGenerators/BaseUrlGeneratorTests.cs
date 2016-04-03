using System;
using System.Text;
using System.Collections.Generic;
using CraftyPucker.Data.Tests;
using CraftyPucker.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CraftyPucker.Data.Tests.UrlGenerators;

namespace CraftyPucker.Data.UrlGenerators.Tests
{
    /// <summary>
    /// Summary description for BaseUrlGeneratorTests
    /// </summary>
    [TestClass]
    public class BaseUrlGeneratorTests
    {

        public BaseUrlGeneratorTests()
        {
            var baseUrlGenerator = new BaseUrlGeneratorImplementation();
            Assert.IsNotNull(baseUrlGenerator);
        }

        [TestMethod()]
        public void HomeGameUrlValid()
        {
            var game = (new GameBuilder())
                .WithHomeTeam()
                .WithAwayTeam()
                .WithHomeMediaFeed()
                .HomeGame()
                .Build();

            var baseUrlGenerator = new BaseUrlGeneratorImplementation();
            var url = baseUrlGenerator.Generate(game.MediaFeeds["HOME"], "CDN");
            Assert.AreEqual(url, new Uri("http://test.com/2016/03/13/NHL_GAME_VIDEO_CHIDET_M2_HOME_20160313/master_wired60.m3u8"));
        }

        [TestMethod()]
        public void AwayGameUrlValid()
        {
            var game = (new GameBuilder())
                .WithHomeTeam()
                .WithAwayTeam()
                .WithAwayMediaFeed()
                .AwayGame()
                .Build();

            var baseUrlGenerator = new BaseUrlGeneratorImplementation();
            var url = baseUrlGenerator.Generate(game.MediaFeeds["AWAY"], "CDN");
            Assert.AreEqual(url, new Uri("http://test.com/2016/03/13/NHL_GAME_VIDEO_CHIDET_M2_VISIT_20160313/master_wired60.m3u8"));

        }
    }
}
