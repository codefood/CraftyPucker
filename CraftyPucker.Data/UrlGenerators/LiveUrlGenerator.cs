using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.UrlGenerators
{
    public class LiveUrlGenerator : BaseUrlGenerator
    {
        public override string GetBaseUrl(string cdn)
        {
            return string.Format("http://hlslive-{0}.med2.med.nhl.com/ls04/nhl", cdn);
        }
    }
}
