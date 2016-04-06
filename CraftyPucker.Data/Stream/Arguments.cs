using CraftyPucker.Data.UrlGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftyPucker.Data.Stream.Parameters;

namespace CraftyPucker.Data.Stream
{
    public class Arguments
    {
        public string Quality { get; set; }
        //public string CDN { get; set; }
        public bool SixtyFps { get; set; }
        public BaseUrlGenerator UrlGenerator { get; set; }
        //public MediaFeed MediaFeed { get; set; }
        public string PlayerPath = @"C:\Program Files\VideoLAN\VLC\vlc.exe";

        public static Arguments GetDefaultArguments()
        {
            return new Arguments
            {
                Quality = CraftyPucker.Data.Stream.Parameters.Quality._720P,
               // CDN = CraftyPucker.Data.Stream.Parameters.CDN.Akami,
                SixtyFps = false
            };
        }

    }
}
