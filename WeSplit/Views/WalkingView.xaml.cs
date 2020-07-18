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
using WeSplit.Models;
using WeSplit.Views;

namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for WalkingView.xaml
    /// </summary>
    public partial class WalkingView : UserControl
    {
        public WalkingView()
        {
            InitializeComponent();
        }

        private void ShowDetail_Click(object sender, MouseButtonEventArgs e)
        {
            HistoryView.isLocatedDetail = true;
            HistoryView.Instance.Animate(0);
            HistoryView.Instance.BtnShow.HorizontalAlignment = HorizontalAlignment.Right;
            HistoryView.Instance.BtnShowBorder.CornerRadius = new CornerRadius(0, 14, 14, 0);
            HistoryView.Instance.BtnHide.Visibility = Visibility.Hidden;
            HistoryView.Instance.BtnShow.Visibility = Visibility.Visible;
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {

        }
    }
}
