using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

        string absolute = "";
        private void convert(string relative)
        {
            absolute = null;
            for (int i = relative.Length - 1; i > 0; i--)
            {

                if (relative[i] == '\\')
                {
                    for (int run = i + 1; run < relative.Length; run++)
                        absolute += relative[run];
                    break;
                }
            }
        }

        List<string> ImagesNameList = new List<string>();
        private void AddImgButton_Click(object sender, RoutedEventArgs e)
        {

            //var screen = new OpenFileDialog();
            //if (screen.ShowDialog() == true)
            //{
            //    _fileAvatar = screen.FileName;
            //    var bitmap = new BitmapImage(new Uri(_fileAvatar, UriKind.Absolute));
            //    AvatarImage.Visibility = Visibility.Hidden;
            //    ContentImg.Visibility = Visibility.Hidden;
            //    AddAvatar.ImageSource = bitmap;
            //}

            //lấy tên ảnh đưa vào list  ImagesNameList
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    convert(filename);
                    ImagesNameList.Add(absolute);
                }
            }

            //đưa ảnh dô file bin
        }

        private void BtnAddListInfoUser_Click(object sender, RoutedEventArgs e)
        {
            Style style_user = this.FindResource("MemberNameBox") as Style;
            Style style_tel = this.FindResource("TelBox") as Style;

            var newTextbox = new TextBox();
            newTextbox.Style = style_user;
            MemberNameStack.Children.Add(newTextbox);

            var newTextbox_tel = new TextBox();
            newTextbox_tel.Style = style_tel;
            TelStack.Children.Add(newTextbox_tel);
        }

        private void BtnAddInfoExpenses_Click(object sender, RoutedEventArgs e)
        {
            Style style_expensesname = this.FindResource("ExpendituresName") as Style;
            Style style_expensesmoney = this.FindResource("MoneyBox") as Style;

            var newExpensesbox = new TextBox();
            newExpensesbox.Style = style_expensesname;
            ExpendituresNameStack.Children.Add(newExpensesbox);

            var newExpensesmoneybox = new TextBox();
            newExpensesmoneybox.Style = style_expensesmoney;
            ExpendituresMoneyStack.Children.Add(newExpensesmoneybox);
        }

        //kiem tra hợp lệ 
        private bool ConditionCheck(List<TextBox> member, List<TextBox> tel, List<TextBox> expensesname, List<TextBox> expensesmoney)
        {
            if (JourneyName.Text.Trim() == "" | Kilometer.Text.Trim() == "" | StartDay.Text.Trim().Length <= 8 |
              EndDay.Text.Trim().Length <= 8 | member.Count < 1 | tel.Count < 1 | expensesname.Count < 1 | expensesmoney.Count < 1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho món ăn!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }


        private List<TextBox> AllChildren(DependencyObject parent)
        {
            var list = new List<TextBox> { };
            for (int count = 0; count < VisualTreeHelper.GetChildrenCount(parent); count++)
            {
                var child = VisualTreeHelper.GetChild(parent, count);
                if (child is TextBox)
                {
                    list.Add(child as TextBox);
                }
                list.AddRange(AllChildren(child));
            }
            return list;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> childrenOfMember = AllChildren(MemberNameStack);
            List<TextBox> childrenOfTel = AllChildren(TelStack);
            List<TextBox> childrenOfExpendituresName = AllChildren(ExpendituresNameStack);
            List<TextBox> childrenOfExpendituresMoney = AllChildren(ExpendituresMoneyStack);


            //kiểm tra đã nhập đầy đủ thông tin 
            if (ConditionCheck(childrenOfMember, childrenOfTel, childrenOfExpendituresName, childrenOfExpendituresMoney))
            {
                //tên chuyến đi
                if (JourneyName.Text.Trim() != "")
                {
                    //trip.TripName = JourneyName.Text;
                }

                //số km
                if (Kilometer.Text.Trim() != "")
                {
                    //trip.Lenght = Kilometer.Text;
                }

                //ngày đi
                if (StartDay.Text.Trim() != "")
                {
                    //trip.StartDate = StartDay.Text;
                }

                //ngày về
                if (EndDay.Text.Trim() != "")
                {
                    //trip.EndDate = EndDay.Text;
                }

                //them vào database về chuyến đi
                // trip.Add();
                //danh sách tên và số điện thoại thành viên
                for (int i = 0; i < childrenOfMember.Count; i++)
                {
                    if (childrenOfMember[i].Text.Trim() != "" && childrenOfTel[i].Text.Trim() != "")
                    {
                        //Member member = new Member();

                        //member.MemberName = childrenOfMember[i].Text;
                        //member.Telephone = childrenOfTel[i].Text;
                        //if (LeaderIndex == i)
                        //{
                        //    member.Status = 1;
                        //}
                        //thêm vào database
                        // member.Add();
                    }
                }//kết thúc danh sách tên và số điện thoại thành viên

                //danh sach tên và số tiền khoản chi 
                for (int i = 0; i < childrenOfExpendituresMoney.Count; i++)
                {
                    if (childrenOfExpendituresMoney[i].Text.Trim() != "" && childrenOfExpendituresName[i].Text.Trim() != "")
                    {
                        //ReceiptsAndExpenses receandexpen = new ReceiptsAndExpenses();
                        //receandexpen.ExpensesName = childrenOfExpendituresMoney[i].Text;
                        //receandexpen.Cost = childrenOfExpendituresName[i].Text;
                        //receandexpen.Add();
                    }
                }//ket thuc lấy danh sach tên và số tiền khoản chi

                //lấy ra tên các lộ trình
                if(RouteName.Text.Trim() != "")
                {

                }
            }
        }
    }
}
