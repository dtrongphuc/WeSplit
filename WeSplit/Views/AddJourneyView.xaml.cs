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
using WeSplit.ViewModels;

namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for AddJourneyView.xaml
    /// </summary>
    public partial class AddJourneyView : UserControl
    {
        public AddJourneyView()
        {
            InitializeComponent();
            StartDay.SelectedDate = DateTime.Today;
            EndDay.SelectedDate = DateTime.Now.AddDays(1);
        }

        //tăng số thứ tự
        private int _memberCount = 1;
        private int _expenseCount = 1;
        private void BtnAddListInfoUser_Click(object sender, RoutedEventArgs e)
        {
            Style style_user = this.FindResource("MemberNameBox") as Style;
            Style style_tel = this.FindResource("TelBox") as Style;
            Style style_ellipse = this.FindResource("EllipseNumber") as Style;
            Style style_Ordinalnum = this.FindResource("NumberTextBlock") as Style;
            Style style_IsLeaderRadioButton = this.FindResource("IsLeaderRadioButton") as Style;

            var newTextbox = new TextBox();
            newTextbox.Style = style_user;
            MemberNameStack.Children.Add(newTextbox);

            var newTextbox_tel = new TextBox();
            newTextbox_tel.Style = style_tel;
            TelStack.Children.Add(newTextbox_tel);

            //Count
            var newCountStack = new StackPanel();
            newCountStack.Height = 60;
            newCountStack.Margin = new Thickness(0, 16, 0, 16);

            var newTextbox_ellipse = new Ellipse();
            newTextbox_ellipse.Style = style_ellipse;
            newCountStack.Children.Add(newTextbox_ellipse);

            var newTextbox_Ordinalnum = new TextBlock();
            newTextbox_Ordinalnum.Style = style_Ordinalnum;
            newTextbox_Ordinalnum.Text = (++_memberCount).ToString();
            newCountStack.Children.Add(newTextbox_Ordinalnum);

            var newRadioButton = new RadioButton();
            newRadioButton.Style = style_IsLeaderRadioButton;
            IsLeader.Children.Add(newRadioButton);

            MemberCount.Children.Add(newCountStack);
        }

        private void BtnAddInfoExpenses_Click(object sender, RoutedEventArgs e)
        {
            Style style_expensesname = this.FindResource("ExpendituresName") as Style;
            Style style_expensesmoney = this.FindResource("MoneyBox") as Style;
            Style style_ellipse = this.FindResource("EllipseNumber") as Style;
            Style style_Ordinalnum = this.FindResource("NumberTextBlock") as Style;

            var newExpensesbox = new TextBox();
            newExpensesbox.Style = style_expensesname;
            ExpendituresNameStack.Children.Add(newExpensesbox);

            var newExpensesmoneybox = new TextBox();
            newExpensesmoneybox.Style = style_expensesmoney;
            ExpendituresMoneyStack.Children.Add(newExpensesmoneybox);

            //Count
            var newCountStack = new StackPanel();
            newCountStack.Height = 60;
            newCountStack.Margin = new Thickness(0, 16, 0, 16);

            var newTextbox_ellipse = new Ellipse();
            newTextbox_ellipse.Style = style_ellipse;
            newCountStack.Children.Add(newTextbox_ellipse);

            var newTextbox_Ordinalnum = new TextBlock();
            newTextbox_Ordinalnum.Style = style_Ordinalnum;
            newTextbox_Ordinalnum.Text = (++_expenseCount).ToString();
            newCountStack.Children.Add(newTextbox_Ordinalnum);

            ExpendituresCount.Children.Add(newCountStack);
        }

        //kiểm tra 
        private bool ConditionCheck(List<TextBox> member, List<TextBox> tel, List<TextBox> expensesname, List<TextBox> expensesmoney)
        {
            if (JourneyName.Text.Trim() == "" | Kilometer.Text.Trim() == "" | StartDay.Text.Trim().Length <= 8 |
              EndDay.Text.Trim().Length <= 8 | member.Count < 1 | tel.Count < 1 | expensesname.Count < 1 | expensesmoney.Count < 1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho chuyến đi!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private List<RadioButton> AllChildrenRadioButton(DependencyObject parent)
        {
            var list = new List<RadioButton> { };
            for (int count = 0; count < VisualTreeHelper.GetChildrenCount(parent); count++)
            {
                var child = VisualTreeHelper.GetChild(parent, count);
                if (child is RadioButton)
                {
                    list.Add(child as RadioButton);
                }
                list.AddRange(AllChildrenRadioButton(child));
            }
            return list;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> childrenOfMember = AllChildren(MemberNameStack);
            List<TextBox> childrenOfTel = AllChildren(TelStack);
            List<TextBox> childrenOfExpendituresName = AllChildren(ExpendituresNameStack);
            List<TextBox> childrenOfExpendituresMoney = AllChildren(ExpendituresMoneyStack);
            List<RadioButton> childrenOfIsLeader = AllChildrenRadioButton(IsLeader);

            Trip trip = new Trip();
            string identity;
            trip.Status = 1;
            int LeaderIndex = -1;

            ///kiểm tra đã nhập đầy đủ thông tin
            if (ConditionCheck(childrenOfMember, childrenOfTel, childrenOfExpendituresName, childrenOfExpendituresMoney))
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

                for (int i = 0; i < childrenOfIsLeader.Count; i++)
                {
                    if (childrenOfIsLeader[i].IsChecked == true)
                    {
                        LeaderIndex = i;
                        break;
                    }
                }
                //them vào database về chuyến đi
                 trip.Add();
                 identity = trip.Identyti(); ;
                //danh sách tên và số điện thoại thành viên
                for (int i = 0; i < childrenOfMember.Count; i++)
                {
                    if (childrenOfMember[i].Text.Trim() != "" && childrenOfTel[i].Text.Trim() != "")
                    {
                        Member member = new Member();
                        member.TripID = identity;
                        member.MemberName = childrenOfMember[i].Text;
                        member.Telephone = childrenOfTel[i].Text;
                        if(LeaderIndex == i)
                        {
                            member.Status = 1;
                        }
                        //thêm vào database
                        member.Add();
                    }
                }//kết thúc danh sách tên và số điện thoại thành viên

                Member member1 = new Member();
                //danh sach tên và số tiền khoản chi 
                for (int i = 0; i < childrenOfExpendituresMoney.Count; i++)
                {
                    if (childrenOfExpendituresMoney[i].Text.Trim() != "" && childrenOfExpendituresName[i].Text.Trim() != "")
                    {
                        ReceiptsAndExpenses receandexpen = new ReceiptsAndExpenses();
                        member1.Leader(identity);
                        receandexpen.MemberID = member1.MemberID;
                        receandexpen.TripID = identity;
                        receandexpen.Cost = Double.Parse(childrenOfExpendituresMoney[i].Text, System.Globalization.NumberStyles.Any);
                        receandexpen.ExpensesName = childrenOfExpendituresName[i].Text;
                        receandexpen.Add();
                    }
                }//ket thuc lấy danh sach tên và số tiền khoản chi

            }//kết thúc thêm vào database
            MessageBox.Show("Thêm chuyến đi thành công!", "Thành công");
        }//két thúc sự kiện click
    }
}
