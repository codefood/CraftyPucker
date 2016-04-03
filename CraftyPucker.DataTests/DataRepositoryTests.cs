using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Tests
{
    [TestClass]
    public class DataRepositoryTests
    {

        private List<Game> LoadTestGames()
        {
            var _games = new List<Game>();
            var g1 = new Game();
            g1.HomeTeam = new Team
            {
                Abbreviation = "DET",
                Name = "Detroit Red Wings"
            };
            g1.AwayTeam = new Team
            {
                Abbreviation = "CHI",
                Name = "Chicago Blackhawks"
            };
            g1.Date = new DateTime(2016, 3, 13, 17, 0, 0);
            g1.MediaFeeds.Add("HOME",
            new MediaFeed
            {
                MediaFeedType = "HOME",
                MediaPlaybackId = "1234"
            });

            ((List<Game>)_games).Add(g1);


            var g2 = new Game();
            g2.HomeTeam = new Team
            {
                Abbreviation = "PIT",
                Name = "Pittsburgh Penguins"
            };
            g2.AwayTeam = new Team
            {
                Abbreviation = "FLA",
                Name = "Florida Panthers"
            };
            g2.Date = new DateTime(2016, 3, 13, 17, 0, 0);
            g2.MediaFeeds.Add("AWAY", new MediaFeed
            {
                MediaFeedType = "AWAY",
                MediaPlaybackId = "1234"
            });

            _games.Add(g2);


            var g3 = new Game();
            g3.HomeTeam = new Team
            {
                Abbreviation = "PIT",
                Name = "Pittsburgh Penguins"
            };
            g3.AwayTeam = new Team
            {
                Abbreviation = "PHI",
                Name = "Philadelphia Flyers"
            };
            g3.Date = new DateTime(2016, 3, 12, 16, 0, 0);
            g3.MediaFeeds.Add("AWAY",
                new MediaFeed
            {
                MediaFeedType = "AWAY",
                MediaPlaybackId = "5678"
            });

            _games.Add(g3);

            return _games;

        }


        [TestMethod]
        public void ReturnsGames()
        {
            var dataRepository = new DataRepository();
            dataRepository.Games = LoadTestGames();
            Assert.IsTrue(dataRepository.Games.Any());
        }

        [TestMethod]
        public void LoadsShit()
        {
            var dataRepository = new DataRepository();
            var games = dataRepository.Games;
            Assert.IsTrue(games.Any());
            Assert.IsTrue(games.Count() == 5);
        }


        [TestMethod]
        public void ReturnsTeams()
        {
            var dataRepository = new DataRepository();
            dataRepository.Games = LoadTestGames();
            Assert.IsTrue(dataRepository.Teams.Count() == 5);
        }

    }
}
