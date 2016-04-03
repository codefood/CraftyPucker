using CraftyPucker.Data.UrlGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Tests.UrlGenerators
{
    public class BaseUrlGeneratorImplementation : BaseUrlGenerator
    {
        public override string GetBaseUrl(string cdn)
        {
            return "http://test.com";
        }
    }
}
