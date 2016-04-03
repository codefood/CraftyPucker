using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.UrlGenerators
{
    public class LiveUrlGenerator : BaseUrlGenerator
    {
        public override string GetBaseUrl()
        {
            return "http://hlslive-CDN.med2.med.nhl.com/ls04/nhl";
        }
    }
}
