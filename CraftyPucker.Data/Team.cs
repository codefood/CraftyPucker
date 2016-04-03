using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data
{
    [DebuggerDisplay("{Abbreviation} ({Name})")]
    public class Team
    {
        public static class HomeAway
        {
            public static string Home = "home";
            public static string Away = "away";
        }

        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public bool IsBestTeamEver()
        {
            return (Abbreviation.Equals("DET", StringComparison.InvariantCultureIgnoreCase));
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Abbreviation, Name);
        }

    }
}
