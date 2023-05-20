using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

namespace TrackMe.Views
{
    public sealed partial class AddPage : Page, INotifyPropertyChanged
    {
        public AddPage()
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
            // Insert data into asset(hardware) database
            DatabaseAccess.AddData1(assetName.Text, type.Text, description.Text, model.Text, manufacturer.Text, internalID.Text, mac.Text, ip.Text, location.Text, purchaseDate.Text, warranty.Text, otherNotes.Text);
            DatabaseAccess.GetData1();
        }

        private void Button_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Insert data into asset2(software) database
            DatabaseAccess.AddData2(softwareProductName.Text, type2.Text, description2.Text, version.Text, developer.Text, licenseType.Text, licenseKey.Text, purchaseDate2.Text, otherNotes2.Text);
            DatabaseAccess.GetData2();
        }
    }
}
