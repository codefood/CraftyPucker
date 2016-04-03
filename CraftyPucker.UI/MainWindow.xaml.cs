using System.Windows;

namespace CraftyPucker.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data.GameRepository _gamesRepo;
        public MainWindow()
        {
            _gamesRepo = new Data.GameRepository();
            InitializeComponent();
            lbGames.ItemsSource = _gamesRepo.Games;
        }
    }
}
