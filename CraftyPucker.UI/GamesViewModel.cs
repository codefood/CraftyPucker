using CraftyPucker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;

namespace CraftyPucker.UI
{
    public class GamesViewModel : INotifyPropertyChanged
    {
        private readonly Data.DataRepository _gamesRepo;

        public CollectionViewSource CollViewSource { get; set; }

        public IEnumerable<Team> Teams => _gamesRepo.Teams;

        private Team _selectedTeam;
        public Team SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                _selectedTeam = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedTeam)));
                _gamesView.Refresh();
            }
        }

        private ICollectionView _gamesView;

        public ICollectionView Games
        {
            get { return _gamesView; }
        }

        public GamesViewModel()
        {
            _gamesRepo = new Data.DataRepository();
            _gamesView = CollectionViewSource.GetDefaultView(_gamesRepo.Games);
            _gamesView.Filter = GameFilter;
        }

        private bool GameFilter(object item)
        {
            Game filterItem = item as Game;
            if (SelectedTeam == null) return true;

            Debug.Assert(filterItem != null, "filterItem != null");
            return filterItem.HomeTeam.Equals(SelectedTeam) || filterItem.AwayTeam.Equals(SelectedTeam);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Clear()
        {
            _selectedTeam = null;
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedTeam)));
            _gamesView.Refresh();
        }

        public ICommand StreamCommand => new Commands.Stream();

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}