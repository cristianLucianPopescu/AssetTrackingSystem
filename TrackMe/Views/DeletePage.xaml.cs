using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;

namespace TrackMe.Views
{
    public sealed partial class DeletePage : Page, INotifyPropertyChanged
    {
        public DeletePage()
        {
            InitializeComponent();
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

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DatabaseAccess.DeleteData1(assetName.Text);
            DatabaseAccess.GetData1();
        }

        private void Button_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DatabaseAccess.DeleteData2(softwareProductName.Text);
            DatabaseAccess.GetData2();
        }
    }
}
