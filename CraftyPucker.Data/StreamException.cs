using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data
{
    public class StreamException : Exception
    {
        public StreamException(string message) : base(message)
        {

        }
    }
}
