using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data
{
    public class GameRepository
    {
        public IEnumerable<Game> Games
        {
            get
            {
                if (_games == null)
                    LoadTestGames();
                return _games;
            }
        }

        private IEnumerable<Game> _games;

        private void LoadGames()
        {
            //var gameDataSource = new JsonSource(DateTime.Now);
            //var gameData = gameDataSource.DownloadJson();
            //var gameLoader = new JsonGameLoader();
            //_games = gameLoader.Load(gameData);
        }

        private void LoadTestGames()
        {
            _games = new List<Game>();
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
            g1.GameType = GameType.Home;
            ((List<MediaFeed>)g1.MediaFeeds).Add(new MediaFeed
            {
                MediaFeedType = "HOME",
                MediaPlaybackId = "1234"
            });

            ((List <Game>)_games).Add(g1);


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
            g2.GameType = GameType.Away;
            ((List<MediaFeed>)g2.MediaFeeds).Add(new MediaFeed
            { 
                MediaFeedType = "VISIT",
                MediaPlaybackId = "1234"
            });

            ((List<Game>)_games).Add(g2);
        }

    }
}
