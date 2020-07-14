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
            //FileInfo info = null;
            //var folderfile = AppDomain.CurrentDomain.BaseDirectory;
            //var newname = "";


            //tên chuyến đi
            if (JourneyName.Text.Trim() != "")
            {
                //them vào chuyến đi 
                //sp.NguyenLieu += element.Text + "\\n";
            }

            //số km
            if (Kilometer.Text.Trim() != "")
            {
                //them vào chuyến đi 
                //sp.NguyenLieu += element.Text + "\\n";
            }

            //ngày đi
            if (StartDay.Text.Trim() != "")
            {
                //them vào chuyến đi 
                //sp.NguyenLieu += element.Text + "\\n";
            }

            //ngày về
            if (EndDay.Text.Trim() != "")
            {
                //them vào chuyến đi 
                //sp.NguyenLieu += element.Text + "\\n";
            }

            //danh sách tên thành viên
            foreach (var element in childrenOfMember)
            {
                if (element.Text.Trim() != "")
                {
                    //them vào chuyến đi 
                    //sp.NguyenLieu += element.Text + "\\n";
                }
            }

            //danh sách số điện thoại thành viên
            foreach (var element in childrenOfTel)
            {
                if (element.Text.Trim() != "")
                {
                    //them vào chuyến đi 
                    //sp.NguyenLieu += element.Text + "\\n";
                }
            }

            //danh sach ten khoản chi
            foreach (var element in childrenOfExpendituresName)
            {
                if (element.Text.Trim() != "")
                {
                    //them vào chuyến đi 
                    //sp.NguyenLieu += element.Text + "\\n";
                }
            }

            //danh sach số tiền khoản chi
            foreach (var element in childrenOfExpendituresMoney)
            {
                if (element.Text.Trim() != "")
                {
                    //them vào chuyến đi 
                    //sp.NguyenLieu += element.Text + "\\n";
                }
            }

        }
    }
}
