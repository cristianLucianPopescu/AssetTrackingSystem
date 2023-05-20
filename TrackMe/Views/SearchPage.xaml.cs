using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;

namespace TrackMe.Views
{
    public sealed partial class SearchPage : Page, INotifyPropertyChanged
    {
        public SearchPage()
        {
            InitializeComponent();
            //NVD.Display();
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

        private async void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //NVD.Search(search.Text);
            //NVD.Display();
            //WebClient client = new WebClient();
            string nistDatabase = $"https://services.nvd.nist.gov/rest/json/cves/1.0?cpeMatchString=cpe:2.3:*:*:{search.Text}";
            //string nistDatabase = client.DownloadString("https://services.nvd.nist.gov/rest/json/cpes/1.0/");
            HttpClient client = new HttpClient();
            string get = await client.GetStringAsync(nistDatabase);
            var data = JsonConvert.DeserializeObject<Rootobject>(get);
            if (search.Text != null)
            {
                string number = data.totalResults.ToString();
                Vulnerabilities.Text = "There were found " + number + " vulnerabilities";
            }
            //Vulnerabilities.Text = data.ToString();

        }
    }
}
