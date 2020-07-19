using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        UpdateJourneyViewModel Data = null;
        private GetListObject GetList = new GetListObject();
        private Trip trip = new Trip();
        public static UpdateJourneyView Instance { get; set; }
        private BindableCollection<ReceiptsAndExpenses> ReceAndExpenlist = new BindableCollection<ReceiptsAndExpenses>();
        private BindableCollection<ReceiptsAndExpenses> UpdateReceAndExpenlist = new BindableCollection<ReceiptsAndExpenses>();
        private int LastID { get; set; } = 0;
        private int LastLocationCount { get; set; } = 0;

        public UpdateJourneyView()
        {
            InitializeComponent();
            Instance = this;
        }

        

        List<FileInfo> ImagesNameList = new List<FileInfo>();
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
                    var info = new FileInfo(filename);
                    ImagesNameList.Add(info);
                }
            }
            if(ImagesNameList.Count > 0)
            {
                ContentImg.Text = "Đã chọn " + ImagesNameList.Count + " ảnh";
            }
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
            var folderfile = AppDomain.CurrentDomain.BaseDirectory;
            var newname = "";
            Data = Main.DataContext as UpdateJourneyViewModel;
            BindableCollection<Member> Members = new BindableCollection<Member>();
            BindableCollection<Location> Locations = new BindableCollection<Location>();
            //BindableCollection<ReceiptsAndExpenses> Expenditures = new BindableCollection<ReceiptsAndExpenses>();
            Members = Data.MembersInComboBox;
            Locations = Data.LocationListbox;
            LastID = UpdateJourneyViewModel.LastIDOfMembers;
            LastLocationCount = UpdateJourneyViewModel.LastOfLocation;

            IEnumerable<Member> NewMembers = Members.Where(
                    i => int.Parse(i.MemberID) > LastID
                );
            IEnumerable<Location> NewLocations = Locations.Where(
                    i => int.Parse(i.Number) > LastLocationCount
                );

            //danh sách thanh viên thêm mới.
            List<Member> ListMember = NewMembers.ToList();
            //danh sách dia diem them moi
            List<Location> ListLocation = NewLocations.ToList();

            //kiểm tra đã nhập đầy đủ thông tin 
            if (ConditionCheck())
            {
                //tên chuyến đi
                if (JourneyName.Text.Trim() != string.Empty)
                {
                    trip.TripName = JourneyName.Text;
                }

                //số km
                if (Kilometer.Text.Trim() != string.Empty)
                {
                    trip.Lenght = Kilometer.Text;
                }

                //ngày đi
                if (StartDay.Text.Trim() != string.Empty)
                {
                    trip.StartDate = StartDay.Text;
                }

                //ngày về
                if (EndDay.Text.Trim() != string.Empty)
                {
                    trip.EndDate = EndDay.Text;
                }

                //them vào database về chuyến đi
                trip.Edit();

                ///danh sách tên và số điện thoại thành viên
                foreach (Member member in ListMember)
                {
                    member.Add();
                }

                BindableCollection<ReceiptsAndExpenses> receandexpen = GetList.Get_AllReceAndExpenTrip(trip.TripID);
                //update khoan chi.
                foreach (ReceiptsAndExpenses updateExpen in UpdateReceAndExpenlist)
                {
                    IEnumerable<ReceiptsAndExpenses> expen = receandexpen.Where(i => i.ExpensesName.ToLower() == updateExpen.ExpensesName);
                    if (expen.Count() == 0)
                    {
                        updateExpen.Add();
                    }
                    else
                    {
                        updateExpen.Edit();
                    }
                }

                foreach(Location location in ListLocation)
                {
                    location.Add();
                }

                foreach(FileInfo info in ImagesNameList)
                {
                    Images imagetrip = new Images();
                    newname = $"{Guid.NewGuid()}{info.Extension}";
                    imagetrip.TripID = trip.TripID;
                    imagetrip.Image = $"Resource/Image/{newname}";
                    info.CopyTo($"{folderfile}Resource\\Images\\{newname}");
                    imagetrip.Add();
                }
            }
            MessageBox.Show("Cập nhật thành công !", "Thành công");
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
            Data = Main.DataContext as UpdateJourneyViewModel;
            if (membername != string.Empty && expensename != string.Empty && cost != string.Empty && Data != null)
            {
                trip.TripIsGoing();
                ReceiptsAndExpenses receandexpen = new ReceiptsAndExpenses();
                IEnumerable<Member> NewMember;
                receandexpen.TripID = trip.TripID;

               
                NewMember = Data.MembersInComboBox.Where(i => i.MemberName.Contains(membername));

                receandexpen.MemberID = NewMember.ElementAt(0).MemberID;


                receandexpen.ExpensesName = expensename;

                receandexpen.Cost = double.Parse(cost);
                UpdateExpenseMoney.Text = string.Empty;
                //thêm tên khoản chi vào bo nhớ tạm
                UpdateReceAndExpenlist.Add(receandexpen);
            }
        }

        private void ExpendituresComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateExpenseMoney.Text = string.Empty;
        }
    }
}
