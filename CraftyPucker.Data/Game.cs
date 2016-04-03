using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace CraftyPucker.Data
{
    [DebuggerDisplay("{HomeTeam.Abbreviation} vs {AwayTeam.Abbreviation} ({Date})")]
    public class Game
    {
        public Game()
        {
            MediaFeeds = new List<MediaFeed>();
        }

        public DateTime Date { get; set;}
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public GameType GameType { get; set; }
        public IEnumerable<MediaFeed> MediaFeeds { get; set; }

        public Uri GetUriForMediaFeed(StreamType streamType, MediaFeed mediaFeed)
        {
            if (HomeTeam == null)
                throw new NullReferenceException("HomeTeam");
            if (AwayTeam == null)
                throw new NullReferenceException("AwayTeam");
            if (!MediaFeeds.Any())
                throw new NullReferenceException("MediaFeeds");

            var baseUrl = GetBaseUrl(streamType);

            var feedType = mediaFeed.MediaFeedType;
            if (GameType == GameType.Away)
                feedType = mediaFeed.MediaFeedType.Replace("AWAY", "VISIT");

            var url = string.Format("{0}/{1}/NHL_GAME_VIDEO_{2}{3}_M2_{4}_{1}/master_wired60.m3u8",
                baseUrl,
                Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/"),
                AwayTeam.Abbreviation,
                HomeTeam.Abbreviation,
                feedType
                );

            return new Uri(url);
        }

        private string GetBaseUrl(StreamType streamType)
        {
            switch (streamType)
            {
                case StreamType.Live:
                    return "http://hlslive-CDN.med2.med.nhl.com/ls04/nhl";
                case StreamType.VOD:
                    return "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/";
                default:
                    throw new InvalidOperationException("Unknown stream type");

            }
        }
    }
}
