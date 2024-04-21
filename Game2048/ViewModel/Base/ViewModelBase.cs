using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Runtime.CompilerServices;

namespace Game2048.ViewModel.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected static void NavigateToPage(Page page, Uri uri)
        {
            NavigationService.GetNavigationService(page).Navigate(uri);
        }
        protected static void End()
        {
            Application.Current.Shutdown();
        }
    }
}