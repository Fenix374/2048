using System.Windows;

namespace Game2048.View.Page
{
    public partial class GamePage
    {
        public GamePage()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Focus();
        }
    }
}