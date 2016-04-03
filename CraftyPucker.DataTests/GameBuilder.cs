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
        private MediaFeed MediaFeed { get; set; }
        private bool Home { get; set; }

        public GameBuilder WithHomeMediaFeed()
        {
            this.MediaFeed = new MediaFeed
            {
                MediaFeedType = MediaFeedType.HOME,
                MediaPlaybackId = "1234"
            };
            return this;
        }

        public GameBuilder WithAwayMediaFeed()
        {
            this.MediaFeed = new MediaFeed
            {
                MediaFeedType = MediaFeedType.AWAY,
                MediaPlaybackId = "4321"
            };
            return this;
        }

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
            if (MediaFeed != null)
                g1.MediaFeeds.Add(MediaFeed.MediaFeedType, MediaFeed);

            return g1;
        }
    }
}
