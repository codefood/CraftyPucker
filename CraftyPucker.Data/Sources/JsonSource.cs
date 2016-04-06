using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Sources
{
    public class JsonSource : ISource
    {
        public string GetData(DateTime date)
        {

            //return System.IO.File.ReadAllText("test.json");
            var formatUrl = "http://statsapi.web.nhl.com/api/v1/schedule?startDate={0:yyyy-MM-dd}&endDate={1:yyyy-MM-dd}&expand=schedule.teams,schedule.game.content.media.epg";
            var startDate = date.AddDays(-30);
            var endDate = date;
            var url = string.Format(formatUrl, startDate, endDate);

            var httpClient = new HttpClient();
            var task = httpClient.GetStringAsync(url);

            Task.WaitAll(task);
            return task.Result;
        }
    }
}
