using System;
using Game2048.Data;
using Game2048.Model;
using Game2048.Commands;
using Game2048.ViewModel.Base;
using System.Collections.ObjectModel;

namespace Game2048.ViewModel
{
    public class StatisticsViewModel : ViewModelBase
    {
        public static NavigationCommand NavigateToMenuPage
        {
            get => new(NavigateToPage, new Uri("View/Page/MenuPage.xaml", UriKind.RelativeOrAbsolute));
        }

        public static ObservableCollection<Player> StatisticsCollection
        {
            get => Statistics.Players;
        }
    }
}