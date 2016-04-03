using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data
{
    [DebuggerDisplay("{HomeTeam.Abbreviation} vs {AwayTeam.Abbreviation} ({Date})")]
    public class Game
    {
        public Game()
        {
            _mediaFeeds = new Dictionary<MediaFeedType, MediaFeed>();
        }

        public DateTime Date { get; set;}
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        //public GameType GameType { get; set; }
        private IDictionary<MediaFeedType, MediaFeed> _mediaFeeds;

        public IDictionary<MediaFeedType, MediaFeed> MediaFeeds
        {
            get
            {
                foreach (var key in _mediaFeeds.Keys)
                {
                    _mediaFeeds[key].ParentGame = this;
                }
                return _mediaFeeds;
            }
            set
            {
                _mediaFeeds = value;
            }
        }
    }
}
