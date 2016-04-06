using CraftyPucker.Data.Stream;
using CraftyPucker.Data.UrlGenerators;
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

    }
}
