using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Sources
{
    public class SourceFactory
    {
        public static ISource Get()
        {
            return new JsonSource();
        }
    }
}
