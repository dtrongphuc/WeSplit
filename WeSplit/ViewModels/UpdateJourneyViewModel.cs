using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WeSplit.Models;
using WeSplit.Views;

namespace WeSplit.ViewModels
{
    class UpdateJourneyViewModel : Screen
    {
        GetListObject GetList = new GetListObject();
        Trip trip = new Trip();

        public BindableCollection<Member> MembersInComboBox { get; set; }
        public BindableCollection<ReceiptsAndExpenses> ExpendituresInComboBox { get; set; }
        public BindableCollection<Location> LocationListbox { get; set; }

        //tên chuyến đi 
        public string JourneyName { get; set; }
        //số km chuyến đi
        public string Kilometer { get; set; }
        //ngày bắt đầu
        public string StartDay { get; set; }
        //ngày kết thúc 
        public string EndDay { get; set; }
        public UpdateJourneyViewModel()
        {
            trip.TripIsGoing();
            //liệt kê trong comnbobox các thành viên
            MembersInComboBox = memberlist(trip.TripID);
            //liệt kệ trong combobox các khoản chi
            ExpendituresInComboBox = expenselist(trip.TripID);
            //liệt kệ trong listview các địa điểm 
            LocationListbox = GetList.Get_AllLocationTrip(trip.TripID);
            //ten chuyến đi
            JourneyName = trip.TripName;
            //số km
            Kilometer = trip.Lenght;
            //ngày bắt đầu
            StartDay = convertdate(trip.StartDate);
            //ngày kết thúc
            
            EndDay = convertdate(trip.EndDate);
        }

        //binding tên các  thành viên trong chuyến đi 
        public BindableCollection<Member> memberlist(string id)
        {
            //binding
            return GetList.Get_AllMemberTrip(id);
        }

        //binding tên các khoản chi
        public BindableCollection<ReceiptsAndExpenses> expenselist(string id)
        {
            //binding
            return GetList.Get_AllReceName(id);
        }

        //convert dd/mm/yyyy --> mm/dd/yyyy
        public string convertdate(string day)
        {
            if (day == "")
                return day;
            string converted = null;
            //dd/mm/yyyy
            //0123456789/
            converted += day[3];
            converted += day[4];
            converted += '/';
            converted += day[0];
            converted += day[1];
            converted += '/';
            converted += day[6];
            converted += day[7];
            converted += day[8];
            converted += day[9];
            return converted;
        }

        public void AddExpense()
        {
            string newExpenditures = UpdateJourneyView.Instance.ExpendituresName.Text.Trim();
            string newCost = UpdateJourneyView.Instance.NewExpenseMoney.Text.Trim();
            if(newExpenditures == "" && newCost == "")
            {

            }
            ReceiptsAndExpenses temp = new ReceiptsAndExpenses()
            {
                TripID = trip.TripID,
                ExpensesName = newExpenditures
            };

            ExpendituresInComboBox.Insert(0, temp);
            UpdateJourneyView.Instance.ExpendituresName.Text = "";
        }
    }
}
