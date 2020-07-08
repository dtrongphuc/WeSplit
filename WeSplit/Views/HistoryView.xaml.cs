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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeSplit.ViewModels;

namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl
    {
        public HistoryView()
        {
            InitializeComponent();
        }

        private void Animate(double unit)
        {
            Storyboard storyboard = (this.Resources["SbShowHistory"] as Storyboard);
            DoubleAnimation animation = storyboard.Children.First() as DoubleAnimation;
            Storyboard.SetTarget(animation, InfoCanvas);
            animation.To = unit;
            storyboard.Begin();
        }

        private void BtnShowHistory(object sender, MouseButtonEventArgs e)
        {
            if (InfoCanvas.ActualWidth < 500)
            {
                Animate(500);
                BtnShow.Visibility = Visibility.Hidden;
                BtnHide.Visibility = Visibility.Visible;
            }
            else
            {
                Animate(280);
                BtnHide.Visibility = Visibility.Hidden;
                BtnShow.Visibility = Visibility.Visible;
            }
        }

        private void ShowDetail(object sender, RoutedEventArgs e)
        {
            Animate(-10);
        }
    }
}
