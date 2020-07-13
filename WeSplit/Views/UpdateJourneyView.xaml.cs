using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for UpdateJourneyView.xaml
    /// </summary>
    public partial class UpdateJourneyView : UserControl
    {
        public UpdateJourneyView()
        {
            InitializeComponent();
        }

        string _fileAvatar;
        private void AddImgButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                _fileAvatar = screen.FileName;
                var bitmap = new BitmapImage(new Uri(_fileAvatar, UriKind.Absolute));
                AvatarImage.Visibility = Visibility.Hidden;
                ContentImg.Visibility = Visibility.Hidden;
                AddAvatar.ImageSource = bitmap;
            }
        }
    }
}
