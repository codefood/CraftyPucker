using CraftyPucker.Data.Loaders;
using CraftyPucker.Data.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyPucker.Data
{
    public class DataRepository
    {

        /// <summary>
        /// Each of the games in the data set.
        /// Ordered by date and Home Team Abbreviation
        /// </summary>
        public IEnumerable<Game> Games
        {
            get
            {
                if (_games == null)
                    LoadGamesForDate(DateTime.Today);

                return _games.OrderByDescending(x => x.Date)
                    .ThenBy(x => x.HomeTeam == null ? "ZZZZZZ" : x.HomeTeam.Abbreviation);
            }
            set
            {
                _games = value;
            }
        }

        /// <summary>
        /// Each of the Teams that are in the Data represented by <see cref="Games"/>.
        /// Ordered by Abbreviation
        /// </summary>
        public IEnumerable<Team> Teams
        {
            get
            {
                return this.Games.Select(x => x.HomeTeam)
                    .Union(this.Games.Select(x => x.AwayTeam))
                    .Distinct()
                    .OrderBy(x => x.Abbreviation);
            }
        }

        private IEnumerable<Game> _games;

        private void LoadGamesForDate(DateTime date)
        {
            var gameDataSource = SourceFactory.Get();
            var gameData = gameDataSource.GetData(date);
            var gameLoader = LoaderFactory.Get();
            _games = gameLoader.Load(gameData);
        }


    }
}
