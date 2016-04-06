using CraftyPucker.Data.UrlGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Stream
{
    public class ArgumentBuilder
    {
        public string Build(Arguments args, string CDN, MediaFeed mediaFeed)
        {
            var ret = "";
            ret += string.Format(" --player \"'{0}'", args.PlayerPath);
            ret += string.Format(" --meta-title '{0}' \"", "CraftyPucker");

            ret += string.Format(" \"hlsvariant://");

            ret += args.UrlGenerator.Generate(mediaFeed, CDN);

            if (args.SixtyFps)
                ret += " name_key=bitrate";

            ret += "\"";

            ret += string.Format(" {0}", args.Quality);
            ret += " --http-no-ssl-verify ";
            return ret;
        }
    }
}
