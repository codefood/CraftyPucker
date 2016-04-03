using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.UrlGenerators
{
    public class VodUrlGenerator : BaseUrlGenerator
    {
        public override string GetBaseUrl()
        {
            return "http://hlsvod-akc.med2.med.nhl.com/ps01/nhl/";
        }
    }
}
