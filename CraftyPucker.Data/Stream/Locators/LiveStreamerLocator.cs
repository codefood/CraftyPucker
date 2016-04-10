using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Stream.Locators
{
    public class LiveStreamerLocator
    {
        public static string Locate()
        {
            var paths = new List<string>
            {
                @"C:\Program Files (x86)\Livestreamer\livestreamer.exe",
                @"C:\Program Files\Livestreamer\livestreamer.exe"
            };

            return paths.First(x => File.Exists(x));
        }
    }
}
