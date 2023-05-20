using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// User main page to browse the databases
    /// </summary>
    public sealed partial class BrowsePage : Page
    {
        public BrowsePage()
        {
            InitializeComponent();
            view.ItemsSource = DatabaseAccess.GetData1();
            view2.ItemsSource = DatabaseAccess.GetData2();
        }
    }
}
