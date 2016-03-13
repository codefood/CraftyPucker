using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data
{
    public class GameRepository
    {
        public List<Game> Games
        {
            get
            {
                if (_games == null)
                    LoadGames();
                return _games;
            }
        }

        private List<Game> _games;

        private void LoadGames()
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
            g1.MediaFeedType = "HOME";
            g1.MediaPlaybackId = "1234";

            _games.Add(g1);


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
            g2.MediaFeedType = "VISIT";
            g2.MediaPlaybackId = "1234";

            _games.Add(g2);
        }

    }
}
