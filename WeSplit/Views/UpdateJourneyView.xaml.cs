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
using WeSplit.ViewModels;



namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for UpdateJourneyView.xaml
    /// </summary>
    public partial class UpdateJourneyView : UserControl
    {
        //private int number = 0;
        private Trip trip = new Trip();
        public static UpdateJourneyView Instance { get; set; }
        private BindableCollection<Location> locationlist = new BindableCollection<Location>();
        private BindableCollection<ReceiptsAndExpenses> ReceAndExpenlist = new BindableCollection<ReceiptsAndExpenses>();
        private BindableCollection<ReceiptsAndExpenses> UpdateReceAndExpenlist = new BindableCollection<ReceiptsAndExpenses>();
        //private int number = 0;
        public UpdateJourneyView()
        {
            InitializeComponent();
            Instance = this;
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

        //kiem tra hợp lệ 
        private bool ConditionCheck()
        {
            if (JourneyName.Text.Trim() == "" | Kilometer.Text.Trim() == "" | StartDay.Text.Trim().Length <= 8 |
              EndDay.Text.Trim().Length <= 8)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho chuyến đi!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (datecheck(StartDay.Text.Trim(), EndDay.Text.Trim()) == false)
            {
                MessageBox.Show("Ngày về phải lớn hơn ngày bắt đầu!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (ImagesNameList.Count < 1)
            {
                MessageBox.Show("Bạn chưa thêm ảnh cho chuyến đi!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }


        //kiểm tra ngày về phải > ngày đi 
        private bool datecheck(string start, string end)
        {
            DateTime _start = DateTime.Parse(start);
            DateTime _end = DateTime.Parse(end);
            DateTime startday = new DateTime(_start.Year, _start.Month, _start.Day);
            DateTime endday = new DateTime(_end.Year, _end.Month, _end.Day);
            if (startday < endday)
                return true;
            return false;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            trip.TripIsGoing();
            //kiểm tra đã nhập đầy đủ thông tin 
            if (ConditionCheck())
            {
                //tên chuyến đi
                if (JourneyName.Text.Trim() != "")
                {
                    trip.TripName = JourneyName.Text;
                }

                //số km
                if (Kilometer.Text.Trim() != "")
                {
                    trip.Lenght = Kilometer.Text;
                }

                //ngày đi
                if (StartDay.Text.Trim() != "")
                {
                    trip.StartDate = StartDay.Text;
                }

                //ngày về
                if (EndDay.Text.Trim() != "")
                {
                    trip.EndDate = EndDay.Text;
                }

                //them vào database về chuyến đi
                trip.Edit();

                //danh sách tên và số điện thoại thành viên
                //foreach (Member menber in )
                //{
                //    expen.Add();
                //}


                foreach (ReceiptsAndExpenses expen in ReceAndExpenlist)
                {
                    expen.Add();
                }

                foreach (ReceiptsAndExpenses updateExpen in UpdateReceAndExpenlist)
                {
                    updateExpen.Add();
                }

                Location numberlocation = new Location();
                int STT = numberlocation.STT(trip.TripID);

                foreach (Location location in locationlist)
                {
                    location.Number = location.Number + STT;
                    location.Add();
                }
            }
        }

        private void AddUpdateExpenses_Click(object sender, RoutedEventArgs e)
        {
            //tên thành viên
            Member MemberSelected = MembersComboBox.SelectedItem as Member;
            string membername = MemberSelected.MemberName;
            ///tên khoản chi
            ReceiptsAndExpenses Expense = ExpendituresComboBox.SelectedItem as ReceiptsAndExpenses;
            string expensename = Expense.ExpensesName;
            ///tiền cần update
            string cost = UpdateExpenseMoney.Text.Trim();
            if (membername != "" && expensename != "" && cost != "")
            {
                trip.TripIsGoing();
                ReceiptsAndExpenses receandexpen = new ReceiptsAndExpenses();
                Member member = new Member();
                receandexpen.TripID = trip.TripID;

                member.Find(trip.TripID, membername);
                receandexpen.MemberID = member.MemberID;


                receandexpen.ExpensesName = expensename;

                receandexpen.Cost = double.Parse(cost);
                //thêm tên khoản chi vào bo nhớ tạm
                UpdateReceAndExpenlist.Add(receandexpen);
            }
        }
    }
}
