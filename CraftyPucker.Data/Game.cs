using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data
{
    public class Game
    {
        public DateTime Date { get; set;}
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public GameType GameType { get; set; }

        public string MediaFeedType { get; set; }

        public string MediaPlaybackId { get; set; }


       public Uri GetStreamURL(StreamType streamType)
        {
            if (HomeTeam == null)
                throw new NullReferenceException("HomeTeam");
            if (AwayTeam == null)
                throw new NullReferenceException("AwayTeam");

            var baseUrl = GetBaseUrl(streamType);

            var feedType = MediaFeedType;
            if (GameType == GameType.Away)
                feedType = MediaFeedType.Replace("AWAY", "VISIT");

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
