using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Loaders
{
    public class LoaderFactory
    {
        public static IGameLoader Get()
        {
            return new JsonGameLoader();
        }
    }
}
