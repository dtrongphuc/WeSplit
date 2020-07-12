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

        private void BtnAddListInfoUser_Click(object sender, RoutedEventArgs e)
        {
            //Style style_user = this.FindResource("MemberNameBox") as Style;
            //Style style_tel = this.FindResource("TelBox") as Style;

            //var newTextbox = new TextBox();
            //newTextbox.Style = style_user;
            //membername.Children.Add(newTextbox);

            //var newTextbox_tel = new TextBox();
            //newTextbox_tel.Style = style_tel;
            //TelStack.Children.Add(newTextbox_tel);
        }

        private void BtnAddInfoExpenses_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            Style style_img = this.FindResource("ButtonAddImg") as Style;
            var newAddImgButton = new Button();
            newAddImgButton.Style = style_img;
            ImgsStack.Children.Add(newAddImgButton);
        }
    }
}
