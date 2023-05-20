using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TrackMe.Services;
using TrackMe.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TrackMe
{
    /// <summary>
    /// Login page where the user has to enter his credentials for getting access to the system.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "admin" && password.Text == "Administrator1.")
            {
                Frame.Navigate(typeof(Views.ShellPage));
            }
            else if (username.Text == "user" && password.Text == "Username2.")
            {
                Frame.Navigate(typeof(BrowsePage));
            }
            else
            {
                error.Text = "Invalid credentials. Please try again";
                //username.Text = " ";
                //password.Text = " ";
            }
            //
            //Frame.Navigate(typeof(Views.ShellPage));
        }
    }
}
