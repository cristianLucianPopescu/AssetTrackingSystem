using Microsoft.Data.Sqlite;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace TrackMe.Views
{
    public sealed partial class EditPage : Page, INotifyPropertyChanged
    {
        public EditPage()
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
            DatabaseAccess.UpdateData1(assetName.Text, type.Text, description.Text, model.Text, manufacturer.Text, internalID.Text, mac.Text, ip.Text, location.Text, purchaseDate.Text, warranty.Text, otherNotes.Text);
            DatabaseAccess.GetData1();
        }

        private void Button_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DatabaseAccess.UpdateData2(softwareProductName.Text, type2.Text, description2.Text, version.Text, developer.Text, licenseType.Text, licenseKey.Text, purchaseDate2.Text, otherNotes2.Text);
            DatabaseAccess.GetData2();
        }

        private void Button_Click_3(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "SELECT * FROM asset WHERE Asset_Name=@searchAssetName;";
                insertCommand.Parameters.AddWithValue("@searchAssetName", searchAssetName.Text);
                SqliteDataReader dataReader = insertCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    assetName.Text = dataReader.GetValue(0).ToString();
                    type.Text = dataReader.GetValue(1).ToString();
                    description.Text = dataReader.GetValue(2).ToString();
                    model.Text = dataReader.GetValue(3).ToString();
                    manufacturer.Text = dataReader.GetValue(4).ToString();
                    internalID.Text = dataReader.GetValue(5).ToString();
                    mac.Text = dataReader.GetValue(6).ToString();
                    ip.Text = dataReader.GetValue(7).ToString();
                    location.Text = dataReader.GetValue(8).ToString();
                    purchaseDate.Text = dataReader.GetValue(9).ToString();
                    warranty.Text = dataReader.GetValue(10).ToString();
                    otherNotes.Text = dataReader.GetValue(11).ToString();
                }
                db.Close();
            }
        }

        private void Button_Click_4(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset2.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "SELECT * FROM asset2 WHERE Software_Product_Name=@searchSoftwareProductName;";
                insertCommand.Parameters.AddWithValue("@searchSoftwareProductName", searchSoftwareProductName.Text);
                SqliteDataReader dataReader = insertCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    softwareProductName.Text = dataReader.GetValue(0).ToString();
                    type2.Text = dataReader.GetValue(1).ToString();
                    description2.Text = dataReader.GetValue(2).ToString();
                    version.Text = dataReader.GetValue(3).ToString();
                    developer.Text = dataReader.GetValue(4).ToString();
                    licenseType.Text = dataReader.GetValue(5).ToString();
                    licenseKey.Text = dataReader.GetValue(6).ToString();
                    purchaseDate2.Text = dataReader.GetValue(7).ToString();
                    otherNotes2.Text = dataReader.GetValue(8).ToString();
                }
                db.Close();
            }
        }
    }
}
