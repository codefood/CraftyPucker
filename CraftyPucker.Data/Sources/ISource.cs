using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Sources
{
    public interface ISource
    {
        string GetData(DateTime date);

    }
}
