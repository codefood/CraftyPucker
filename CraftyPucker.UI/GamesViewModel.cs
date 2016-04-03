using CraftyPucker.Data;
using System.Collections.Generic;
using System.Windows.Data;

namespace CraftyPucker.UI
{
    public class GamesViewModel
    {
        private readonly Data.DataRepository _gamesRepo;

        public CollectionViewSource CollViewSource { get; set; }

        public IEnumerable<Game> Games => _gamesRepo.Games;

        public GamesViewModel()
        {
            _gamesRepo = new Data.DataRepository();
            CollViewSource = new CollectionViewSource {Source = Games};
        }
    }
}