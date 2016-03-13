using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Loaders
{
    public interface IGameLoader
    {
        IEnumerable<Game> Load(object source);
    }
}
