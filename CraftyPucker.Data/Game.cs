using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CraftyPucker.Data
{
    [DebuggerDisplay("{HomeTeam.Abbreviation} vs {AwayTeam.Abbreviation} ({Date})")]
    public class Game
    {
        public Game()
        {
            _mediaFeeds = new Dictionary<string, MediaFeed>();
        }

        public DateTime Date { get; set;}

        public string DateString => Date.ToShortDateString();

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        //public GameType GameType { get; set; }
        private IDictionary<string, MediaFeed> _mediaFeeds;

        public bool IsLive => DateTime.Now.Subtract(Date).TotalHours <= 24;

        public IDictionary<string, MediaFeed> MediaFeeds
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
