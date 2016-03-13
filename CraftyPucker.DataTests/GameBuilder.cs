using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Tests
{
    class GameBuilder
    {

        private Team HomeTeam { get; set; }
        private Team AwayTeam { get; set; }
        private bool Home { get; set; }

        public GameBuilder WithHomeTeam()
        {
            this.HomeTeam = new Team
            {
                Abbreviation = "DET",
                Name = "Detroit Red Wings"
            };
            return this;
        }

        public GameBuilder WithAwayTeam()
        {
            this.AwayTeam = new Team
            {
                Abbreviation = "CHI",
                Name = "Chicago Blackhawks"
            };
            return this;
        }

        public GameBuilder HomeGame()
        {
            this.Home = true;
            return this;
        }

        public GameBuilder AwayGame()
        {
            this.Home = false;
            return this;
        }

        public Game Build()
        {
            var g1 = new Game();
            g1.HomeTeam = HomeTeam;
            g1.AwayTeam = AwayTeam;
            g1.Date = new DateTime(2016, 3, 13, 17, 0, 0);
            g1.MediaPlaybackId = "1234";
            if (Home)
            {
                g1.GameType = GameType.Home;
                g1.MediaFeedType = "HOME";
            }
            else
            {
                g1.GameType = GameType.Away;
                g1.MediaFeedType = "VISIT";
            }
            


            return g1;
        }
    }
}
