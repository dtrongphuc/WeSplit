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

        private bool isLocatedDetail { get; set; } = false;
        private void BtnShowHistory(object sender, MouseButtonEventArgs e)
        {
            ContentControl control = (ContentControl) this.Parent;
            Grid Main = (Grid)control.Parent;
            var MainWidth = Main.ActualWidth;
            
            if (InfoCanvas.ActualWidth < MainWidth * 0.6 && !isLocatedDetail || InfoCanvas.ActualWidth < 10)
            {
                Animate(MainWidth * 0.6);
                BtnShow.HorizontalAlignment = HorizontalAlignment.Center;
                BtnShowBorder.CornerRadius = new CornerRadius(50);
                BtnShow.Visibility = Visibility.Hidden;
                BtnHide.Visibility = Visibility.Visible;
            }
            else if (isLocatedDetail)
            {
                Animate(-14);
                BtnShow.HorizontalAlignment = HorizontalAlignment.Right;
                BtnShowBorder.CornerRadius = new CornerRadius(0, 14, 14, 0);
                BtnHide.Visibility = Visibility.Hidden;
                BtnShow.Visibility = Visibility.Visible;
            }
            else
            { 
                Animate(280);
                BtnHide.Visibility = Visibility.Hidden;
                BtnShow.Visibility = Visibility.Visible;
            }
        }

        private void ShowDetail(object sender, MouseButtonEventArgs e)
        {
            isLocatedDetail = true;
            BtnHide.Visibility = Visibility.Visible;
            BtnShow.Visibility = Visibility.Hidden;
        }
    }
}
