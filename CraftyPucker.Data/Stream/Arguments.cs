using CraftyPucker.Data.UrlGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftyPucker.Data.Stream.Parameters;
using CraftyPucker.Data.Stream.Locators;

namespace CraftyPucker.Data.Stream
{
    public class Arguments
    {
        public string Quality { get; set; }
        public bool SixtyFps { get; set; }
        public BaseUrlGenerator UrlGenerator { get; set; }
        public string PlayerPath
        {
            get; set;
        }

        public static Arguments GetDefaultArguments()
        {
            return new Arguments
            {
                PlayerPath = VideoPlayerLocator.Locate(),
                Quality = CraftyPucker.Data.Stream.Parameters.Quality._720P,
                SixtyFps = false
            };
        }

    }
}
