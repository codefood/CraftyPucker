using Microsoft.VisualStudio.TestTools.UnitTesting;
using CraftyPucker.Data.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftyPucker.Data.Tests;

namespace CraftyPucker.Data.Stream.Tests
{
    [TestClass()]
    public class ArgumentBuilderTests
    {
     

        [TestMethod()]
        public void BuildTest()
        {
            var gameBuilder = new GameBuilder();
            var game = gameBuilder.HomeGame()
                            .WithHomeTeam()
                            .WithAwayTeam()
                            .WithHomeMediaFeed()
                            .Build();

            var args = new Arguments();
            args.Quality = CraftyPucker.Data.Stream.Parameters.Quality._720P;
            args.UrlGenerator = new CraftyPucker.Data.Tests.UrlGenerators.BaseUrlGeneratorImplementation();
            var argBuilder = new ArgumentBuilder();

            var arguments = argBuilder.Build(args, "CDN", game.MediaFeeds[game.MediaFeeds.Keys.First()]);
            var test = " --player \"'C:\\Program Files\\VideoLAN\\VLC\\vlc.exe' --meta-title 'CraftyPucker' \" \"hlsvariant://http://test.com/2016/03/13/NHL_GAME_VIDEO_CHIDET_M2_HOME_20160313/master_wired60.m3u8\" 720P --http-no-ssl-verify ";
            Console.WriteLine(arguments);
            Console.WriteLine(test);

            if (System.IO.File.Exists("FUCK.txt"))
                System.IO.File.Delete("FUCK.txt");
            System.IO.File.WriteAllText("FUCK.txt", arguments + "\r\n" + test);

            Assert.IsTrue(arguments.Equals(test));
        }
    }
}