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
using System.Windows.Shapes;
using System.Configuration;

namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        List<string> _content = new List<string>()
        {
            "Đến Đà Lạt không đùa với tâm linh được đâu 😈",
            "Đi Hà Giang thì không nên bỏ lỡ cảnh ruộng bậc thang Hoàng Su Phì 😍",
            "Bạn đã đến nơi tận cùng tổ quốc chưa nè",
            "Không lòng vòng em như Hải Phòng, thích anh rồi phải không??",
            "Checkin con đường đẹp nhất Viết Nam chưa nào, Phan Thiết thẳng tiến!!",
            "Người ta đồn Đi Đà Lạt với người yêu về là sẽ chia tay đấy 😝 😜",
            "Nên thử cảm giác săn mây ở SaPa một lần trong đời nha 💭"
        };
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkboxdisplay.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ShowSplash"].Value = "false";
                config.Save(ConfigurationSaveMode.Modified);
            }
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random _rng = new Random();
            var content_wellcome = _content[(_rng.Next(0, _content.Count - 1))];
            ContentWellcome.DataContext = content_wellcome;
        }
    }
}
