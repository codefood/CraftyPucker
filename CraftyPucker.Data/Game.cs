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
            MediaFeeds = new Dictionary<MediaFeedType, MediaFeed>();
        }

        public DateTime Date { get; set;}

        public string DateString => Date.ToShortDateString();

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        //public GameType GameType { get; set; }
        public IDictionary<MediaFeedType, MediaFeed> MediaFeeds { get; set; }
        
    }
}
