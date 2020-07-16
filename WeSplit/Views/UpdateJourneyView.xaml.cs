using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WeSplit.Models;

namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for UpdateJourneyView.xaml
    /// </summary>
    public partial class UpdateJourneyView : UserControl
    {
        GetListObject findmember = new GetListObject();
        Trip trip = new Trip();
        
        public UpdateJourneyView()
        {
            InitializeComponent();
            //liệt kê trong comnbobox các thành viên
            memberlist();
            //liệt kệ trong combobox các khoản chi
            expenselist();
        }

        //binding tên các  thành viên trong chuyến đi 
        public void memberlist()
        {
            //chuyến đang đi 
            trip.TripIsGoing();
            //danh sách thành viên trong chuyến đang đi 
            BindableCollection<Member> membergoing = findmember.Get_AllMemberTrip(trip.TripID);
            //binding
            MembersComboBox.ItemsSource = membergoing;
        }

        //binding tên các khoản chi
        public void expenselist()
        {
            //chuyến đang di 
            trip.TripIsGoing();
            //khoản chi trong chuyến đang đi 
            BindableCollection<ReceiptsAndExpenses> expensegoing = findmember.Get_AllReceAndExpenTrip(trip.TripID);
            //binding
            ExpendituresComboBox.ItemsSource = expensegoing;
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

        //kiem tra hợp lệ 
        private bool ConditionCheck(List<TextBox> member, List<TextBox> tel)
        {
            if (JourneyName.Text.Trim() == "" | Kilometer.Text.Trim() == "" | StartDay.Text.Trim().Length <= 8 |
              EndDay.Text.Trim().Length <= 8 | member.Count < 1 | tel.Count < 1)
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
            

            //kiểm tra đã nhập đầy đủ thông tin 
            if (ConditionCheck(childrenOfMember, childrenOfTel))
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
                        
                    }
                }//kết thúc danh sách tên và số điện thoại thành viên

                

                //lấy ra tên thành viên ứng tiền trước
                if (MembersComboBox.Text.Trim() != "")
                {

                }

               
                //lấy ra tên các lộ trình
                if (RouteName.Text.Trim() != "")
                {

                }
            }
        }

        private void AddUpdateExpenses_Click(object sender, RoutedEventArgs e)
        {
            //tiền cần update
            UpdateExpenseMoney.Text.Trim();
            //tên thành viên
            var membername = MembersComboBox.SelectedItem.ToString();
            //tên khoản chi
            var expensename = ExpendituresComboBox.SelectedItem.ToString();
            //thêm vào database 
            //...
        }

        //private void MembersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
            
        //}

        //private void MembersComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    MembersComboBox.Foreground = Brushes.White;
        //}
    }
}
