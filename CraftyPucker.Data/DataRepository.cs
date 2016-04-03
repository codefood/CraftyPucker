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


        public IEnumerable<Game> Games
        {
            get
            {
                if (_games == null)
                    LoadGames();
                return _games;
            }
            set
            {
                _games = value;
            }
        }

        public IEnumerable<Team> Teams
        {
            get
            {
                return this.Games.Select(x => x.HomeTeam)
                    .Union(this.Games.Select(x => x.AwayTeam))
                    .Distinct();
            }
        }

        private IEnumerable<Game> _games;

        private void LoadGames()
        {
            var gameDataSource = new JsonSource();
            var gameData = gameDataSource.GetData(DateTime.Now);
            var gameLoader = new JsonGameLoader();
            _games = gameLoader.Load(gameData);
        }


    }
}
