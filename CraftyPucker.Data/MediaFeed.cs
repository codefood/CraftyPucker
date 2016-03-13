﻿using System;
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

        public string MediaFeedType { get; set; }

        public string MediaPlaybackId { get; set; }

    }
}