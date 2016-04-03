using CraftyPucker.Data.Stream;
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

        public MediaFeed()
        {
            Available = true;
        }

        public Game ParentGame { get; set; }

        public string MediaFeedType { get; set; }

        public string MediaPlaybackId { get; set; }

        public bool Available { get; set; }

        public void Stream()
        {
            Stream(Arguments.GetDefaultArguments());
        }

        private void Stream(Arguments args)
        {
            var streamer = new Streamer();
            streamer.StreamGame(args, this);
        }

    }
}
