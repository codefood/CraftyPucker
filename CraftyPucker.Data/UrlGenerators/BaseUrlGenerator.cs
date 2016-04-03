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

        public Uri Generate(MediaFeed mediaFeed, string cdn)
        {
            if (mediaFeed == null)
                throw new NullReferenceException("mediaFeed");
            if (mediaFeed.ParentGame == null)
                throw new ArgumentNullException("game");
            if (mediaFeed.ParentGame.HomeTeam == null)
                throw new NullReferenceException("game.HomeTeam");
            if (mediaFeed.ParentGame.AwayTeam == null)
                throw new NullReferenceException("game.AwayTeam");


            var baseUrl = GetBaseUrl(cdn);

            var url = string.Format("{0}/{1}/NHL_GAME_VIDEO_{2}{3}_M2_{4}_{5}/master_wired60.m3u8",
                baseUrl,
                mediaFeed.ParentGame.Date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture),                mediaFeed.ParentGame.AwayTeam.Abbreviation,
                mediaFeed.ParentGame.HomeTeam.Abbreviation,
                mediaFeed.MediaFeedType.ToString().Replace("AWAY", "VISIT"),
                mediaFeed.ParentGame.Date.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
                );

            return new Uri(url);
        }

        public abstract string GetBaseUrl(string cdn);


    }
}
