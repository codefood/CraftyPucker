using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.UrlGenerators
{
    public abstract class BaseUrlGenerator
    {
        public string BaseUrl { get; }
        public string DateFormat { get { return "yyyy/MM/dd"; } }
        public const string URL_FORMAT = "{0}/{1}/NHL_GAME_VIDEO_{2}{3}_M2_{4}_{1}/master_wired60.m3u8";

        public Uri Generate(Game game, MediaFeed mediaFeed)
        {
            if (game == null)
                throw new ArgumentNullException("game");
            if (game.HomeTeam == null)
                throw new NullReferenceException("game.HomeTeam");
            if (game.AwayTeam == null)
                throw new NullReferenceException("game.AwayTeam");
            if (mediaFeed == null)
                throw new NullReferenceException("mediaFeed");

            var baseUrl = GetBaseUrl();

            var url = string.Format("{0}/{1}/NHL_GAME_VIDEO_{2}{3}_M2_{4}_{1}/master_wired60.m3u8",
                baseUrl,
                game.Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture).Replace("-", "/"),
                game.AwayTeam.Abbreviation,
                game.HomeTeam.Abbreviation,
                mediaFeed.MediaFeedType.ToString().Replace("AWAY", "VISIT")
                );

            return new Uri(url);
        }

        public abstract string GetBaseUrl();


    }
}
