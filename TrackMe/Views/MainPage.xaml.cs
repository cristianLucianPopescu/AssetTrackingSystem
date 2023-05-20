using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;
using Windows.UI.Xaml.Controls;

namespace TrackMe.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            view.ItemsSource = DatabaseAccess.GetData1();
            view2.ItemsSource = DatabaseAccess.GetData2();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Create a full backup of the asset database (hardware)
            DatabaseAccess.BackupDB1();

            // Create a full backup of the asset2 database (software)
            DatabaseAccess.BackupDB2();
        }
    }
}
