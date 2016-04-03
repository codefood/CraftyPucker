﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data.Loaders
{
    public class JsonGameLoader : IGameLoader
    {
        public IEnumerable<Game> Load(object source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var games = new List<Game>();

            var jobject = JObject.Parse(source.ToString());
            var dates = jobject["dates"];
            foreach (var date in dates)
            {
                games.AddRange(LoadGamesFromDate(date));
            }

            return games;

        }

        private IEnumerable<Game> LoadGamesFromDate(JToken date)
        {

            var gameDate = DateTime.Parse(date["date"].ToString());
            foreach(var gameItem in date["games"])
            {
                var game = new Game();
                game.Date = gameDate;
                game.HomeTeam = LoadTeam(Team.HomeAway.Home, gameItem);
                game.AwayTeam = LoadTeam(Team.HomeAway.Away, gameItem);

                //augh how do you know if it is home or away
                //load media content from ("content")("media")("epg")
                var mediaItems = gameItem["content"]["media"]["epg"]
                    .Where(x => x["title"].ToString().Equals("NHLTV"));

                game.MediaFeeds = LoadMediaFeedsFromList(mediaItems);

                //switch (game.MediaFeeds.Keys.First())
                //{
                //    case MediaFeedType.HOME:
                //        game.GameType = GameType.Home;
                //        break;
                //    case MediaFeedType.AWAY:
                //        game.GameType = GameType.Away;
                //        break;
                //    case MediaFeedType.NATIONAL:
                //        game.GameType = GameType.National;
                //        break;
                //    case MediaFeedType.FRENCH:
                //        game.GameType = GameType.French;
                //        break;
                //    default:
                //        throw new InvalidOperationException("Unknown gametype");
                //}

                yield return game;
            }
        }

        private IDictionary<string, MediaFeed> LoadMediaFeedsFromList(IEnumerable<JToken> mediaFeeds)
        {
            var mediaFeedDict = new Dictionary<string, MediaFeed>();
            foreach (var mediaFeedItem in mediaFeeds)
            {
                foreach (var item in mediaFeedItem["items"])
                {
                    var mediaFeed = new MediaFeed();
                    //MediaFeedType mediaFeedType;
                    var mediaFeedTypeValue = item["mediaFeedType"].ToString().ToUpper();
                    //if (!Enum.TryParse(mediaFeedTypeValue, out mediaFeedType))
                    //    throw new ArgumentOutOfRangeException("mediaFeedType");

                    mediaFeed.MediaFeedType = mediaFeedTypeValue;
                    mediaFeed.MediaPlaybackId = item["mediaPlaybackId"].ToString();

                    if (mediaFeedDict.Keys.Contains(mediaFeedTypeValue))
                        continue;

                    mediaFeedDict.Add(mediaFeedTypeValue, mediaFeed);
                }
            }
            return mediaFeedDict;
        }

        private Team LoadTeam(string homeAway, JToken game)
        {
            //+		game["teams"]["away"]["team"]["abbreviation"]	{PIT}	Newtonsoft.Json.Linq.JToken {Newtonsoft.Json.Linq.JValue}

            var teamItem = game["teams"][homeAway]["team"];
            var team = new Team();
            team.Abbreviation = teamItem["abbreviation"].ToString();
            team.Name = teamItem["teamName"].ToString();
            return team;
        }

    }
}
