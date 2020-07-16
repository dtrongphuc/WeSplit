using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSplit.Models;

namespace WeSplit.ViewModels
{
    class UpdateJourneyViewModel:Screen
    {
        GetListObject findmember = new GetListObject();
        Trip trip = new Trip();
        public BindableCollection<Member> MembersComboBox { get; set; }
        public BindableCollection<ReceiptsAndExpenses> ExpendituresComboBox { get; set; }
        public BindableCollection<Location> LocationListbox { get; set; }

        public UpdateJourneyViewModel() 
        {
            trip.TripIsGoing();
            //liệt kê trong comnbobox các thành viên
            MembersComboBox = memberlist(trip.TripID);
            //liệt kệ trong combobox các khoản chi
            ExpendituresComboBox = expenselist(trip.TripID);
            //liệt kệ trong listview các địa điểm 
            LocationListbox = findmember.Get_AllLocationTrip(trip.TripID);
        }

        //binding tên các  thành viên trong chuyến đi 
        public BindableCollection<Member> memberlist(string id)
        {
            //binding
            return findmember.Get_AllMemberTrip(id);
        }

        //binding tên các khoản chi
        public BindableCollection<ReceiptsAndExpenses> expenselist(string id)
        {
            //binding
            return findmember.Get_AllReceAndExpenTrip(id);
        }

        //binding danh sách địa điểm chuyến đang đi 
        //public BindableCollection<Location> locallist(string id)
        //{            
        //    ////binding
        //    return findmember.Get_AllLocationTrip(id);
        //}
    }
}
