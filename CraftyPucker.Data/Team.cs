using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data
{
    public class Team
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public bool IsBestTeamEver()
        {
            return (Abbreviation.Equals("DET", StringComparison.InvariantCultureIgnoreCase));
        }

    }
}
