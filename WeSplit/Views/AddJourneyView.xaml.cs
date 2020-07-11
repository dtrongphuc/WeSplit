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

        private void BtnAddListInfoUser_Click(object sender, RoutedEventArgs e)
        {
            Style style_user = this.FindResource("UserNameBox") as Style;
            Style style_tel = this.FindResource("TelBox") as Style;
            Style style_money = this.FindResource("MoneyBox") as Style;

            var newTextbox = new TextBox();
            newTextbox.Style = style_user;
            Username.Children.Add(newTextbox);

            var newTextbox_tel = new TextBox();
            newTextbox_tel.Style = style_tel;
            Telnum.Children.Add(newTextbox_tel);
            
            var newTextbox_money = new TextBox();
            newTextbox_money.Style = style_money;
            Money.Children.Add(newTextbox_money);
        }

        private void BtnAddStepField_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnAddInfoExpenses_Click(object sender, RoutedEventArgs e)
        {
            Style style_expensesname = this.FindResource("ExpensesBox") as Style;
            Style style_expensesmoney = this.FindResource("ExpensesMoneyBox") as Style;

            var newExpensesbox = new TextBox();
            newExpensesbox.Style = style_expensesname;
            Expensesname.Children.Add(newExpensesbox);

            var newExpensesmoneybox = new TextBox();
            newExpensesmoneybox.Style = style_expensesmoney;
            Expensesmoney.Children.Add(newExpensesmoneybox);
        }
    }
}
