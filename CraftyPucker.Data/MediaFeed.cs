using CraftyPucker.Data.Stream;
using CraftyPucker.Data.UrlGenerators;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data
{
    [DebuggerDisplay("{MediaFeedType}:{MediaPlaybackId}")]
    public class MediaFeed
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Game ParentGame { get; set; }

        public string MediaFeedType { get; set; }

        public string MediaPlaybackId { get; set; }

        public bool Available
        {
            get
            {
                if (ParentGame == null)
                    return false;

                //Game is not in the future
                if (ParentGame.Date > DateTime.Now)
                    return false;

                //there is actual media available
                if (String.IsNullOrEmpty(MediaPlaybackId))
                    return false;

                return true;
            }
        }

        public void Stream()
        {
            logger.Info(string.Format("Beginning stream of {0}", this));
            var args = Arguments.GetDefaultArguments();
            if (ParentGame.IsLive)
                args.UrlGenerator = new LiveUrlGenerator();
            else
                args.UrlGenerator = new VodUrlGenerator();

            Stream(args);
        }

        private void Stream(Arguments args)
        {
            var streamer = new Streamer();
            streamer.StreamGame(args, this);
        }

        public override string ToString()
        {
            var ret = string.Format("{0}: {1}", MediaFeedType, MediaPlaybackId);
            if (ParentGame == null)
                return ret;

            return string.Format("{0} - {1}", ParentGame, ret);

        }

    }
}
