using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CraftyPucker.Data.Stream
{
    public class VideoPlayerLocator
    {
        public static string Locate()
        {
            var paths = new List<string>
            {
                @"C:\Program Files\VideoLAN\VLC\vlc.exe",
                @"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe"
            };

            //TODO: Just gonna blow up if VLC is installed somewhere weird...
            return paths.First(x => File.Exists(x));
        }
    }
}
