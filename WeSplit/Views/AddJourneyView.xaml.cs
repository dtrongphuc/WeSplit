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

        private void BtnAddAvatar(object sender, RoutedEventArgs e)
        {

        }

        //tăng số thứ tự
        int OrdinalNumMember = 1;
        int OrdinalNumExpense = 1;

        private void BtnAddListInfoUser_Click(object sender, RoutedEventArgs e)
        {
            Style style_user = this.FindResource("MemberNameBox") as Style;
            Style style_tel = this.FindResource("TelBox") as Style;
            Style style_ellipse = this.FindResource("EllipseNumberMember") as Style;
            Style style_Ordinalnum = this.FindResource("NumMemberTextBlock") as Style;

            var newTextbox = new TextBox();
            newTextbox.Style = style_user;
            MemberNameStack.Children.Add(newTextbox);

            var newTextbox_tel = new TextBox();
            newTextbox_tel.Style = style_tel;
            TelStack.Children.Add(newTextbox_tel);

            var newTextbox_ellipse = new Ellipse();
            newTextbox_ellipse.Style = style_ellipse;
            ElippseMemberStack.Children.Add(newTextbox_ellipse);

            var newTextbox_Ordinalnum = new TextBlock();
            newTextbox_Ordinalnum.Style = style_Ordinalnum;
            OrdinalMemberStack.Children.Add(newTextbox_Ordinalnum); 
        }

        private void BtnAddStepField_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnAddInfoExpenses_Click(object sender, RoutedEventArgs e)
        {
            Style style_expensesname = this.FindResource("ExpendituresName") as Style;
            Style style_expensesmoney = this.FindResource("MoneyBox") as Style;
            Style style_ordinalexpensename = this.FindResource("EllipseExpenMember") as Style;
            Style style_ordinalexpensemonet = this.FindResource("NumExpenTextBlock") as Style;

            var newExpensesbox = new TextBox();
            newExpensesbox.Style = style_expensesname;
            ExpendituresNameStack.Children.Add(newExpensesbox);

            var newExpensesmoneybox = new TextBox();
            newExpensesmoneybox.Style = style_expensesmoney;
            ExpendituresMoneyStack.Children.Add(newExpensesmoneybox);

            var newTextbox_ellipse = new Ellipse();
            newTextbox_ellipse.Style = style_ordinalexpensename;
            ElippseExpenStack.Children.Add(newTextbox_ellipse);

            var newTextbox_Ordinalnum = new TextBlock();
            newTextbox_Ordinalnum.Style = style_ordinalexpensemonet;
            OrdinalExpenStack.Children.Add(newTextbox_Ordinalnum);         
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
