using System.Windows;

namespace CraftyPucker.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data.DataRepository _gamesRepo;
        public MainWindow()
        {
            _gamesRepo = new Data.DataRepository();
            InitializeComponent();
            lbGames.ItemsSource = _gamesRepo.Games;
        }
    }
}
