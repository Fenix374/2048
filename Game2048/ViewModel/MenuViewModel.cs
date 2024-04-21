using System;
using Game2048.Commands;
using Game2048.ViewModel.Base;

namespace Game2048.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        public NavigationCommand NavigateToGamePage
        {
            get => new(NavigateToPage, new Uri("View/Page/GamePage.xaml", UriKind.RelativeOrAbsolute));
        }

        public static NavigationCommand NavigateToStatisticsPage
        {
            get => new(NavigateToPage, new Uri("View/Page/StatisticsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        public static RelayCommand EndGameCommand
        {
            get => new(End);
        }
    }
}