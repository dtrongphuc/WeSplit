using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Show();

            var config = ConfigurationManager.AppSettings["ShowSplash"];
            if (config.ToLower() == "true")
            {
                var screen = new Views.SplashScreen();
                screen.ShowDialog();
            }
        }



        private void OnNotHomeClick(object sender, MouseButtonEventArgs e)
        {
            HistoryViewModel.Visibility = Visibility.Collapsed;
        }

        private void OnHomeClick(object sender, MouseButtonEventArgs e)
        {
            HistoryViewModel.Visibility = Visibility.Visible;
        }
    }
}
