using System.Windows;

namespace CraftyPucker.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GamesViewModel _gamesRepo;
        public MainWindow()
        {
            InitializeComponent();
            _gamesRepo = new GamesViewModel();
            this.DataContext = _gamesRepo;
        }
    }
}
