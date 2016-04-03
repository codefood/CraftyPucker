using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Sources
{
    public class JsonSource : ISource
    {
        public object GetData(DateTime date)
        {

            return System.IO.File.ReadAllText("test.json");
            //var formatUrl = "http://statsapi.web.nhl.com/api/v1/schedule?startDate={0:yyyy-MM-dd}&endDate={1:yyyy-MM-dd}&expand=schedule.teams,schedule.game.content.media.epg";
        }
    }
}
