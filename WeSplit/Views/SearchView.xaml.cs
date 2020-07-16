using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
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
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public IEnumerable<Member> list1;
        public IEnumerable<Location> list;
        public IEnumerable<Location> subnets;
        public IEnumerable<Member> subnets1;
        public BindableCollection<ExpandoObject> ListResult = new BindableCollection<ExpandoObject>(); //list chứa kết quả cuối cùng.
        public int _count = 0;
        string keysearchtext = null;
        GetListObject page = new GetListObject();
        public object CategoryList { get; private set; }

        public SearchView()
        {
            InitializeComponent();
        }

        //từ tìm kiếm lưu trong "keysearchtext"
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var l = new GetListObject();
            keysearchtext = SearchBox.Text.Trim();
            list = search_keywordLocation(keysearchtext);
            list1 = search_keywordMember(keysearchtext);

            if (list.Count() != 0)
            {
                foreach (var lo in list)
                {
                    dynamic trip = new ExpandoObject();
                    //trip.Find(lo.TripID);
                    trip = l.Get_JourneyCustom(lo.TripID);
                    ListResult.Add(trip);
                }

            }
            else if (list1.Count() != 0)
            {
                foreach (var lo in list1)
                {
                    dynamic trip = new ExpandoObject();
                    trip = l.Get_JourneyCustom(lo.TripID);
                    //trip.Find(lo.TripID);
                    ListResult.Add(trip);
                }
            }
            else
            {
                Search.ItemsSource = null;
            }
            Search.ItemsSource = ListResult;
            _count = ListResult.Count();
            Quantity.Text = "Có " + _count + " kết quả được tìm thấy";
        }

        //tìm kiếm theo dia diem chuyến đi 
        public IEnumerable<Location> search_keywordLocation(string keyword)
        {
            BindableCollection<Location> location = page.Get_AllLocation();

            if (keyword == "")
            {
                return subnets;
            }
            else
            {
                subnets = location.Where(i => i.LocationName.ToLower().Contains(keyword.ToLower()));
            }
            return subnets;
        }

        //tìm  kiếm teo tên thành viên
        public IEnumerable<Member> search_keywordMember(string keyword)
        {
            BindableCollection<Member> member = page.Get_AllMember();

            if (keyword == "")
            {
                return subnets1;
            }
            else
            {
                subnets1 = member.Where(i => i.MemberName.ToLower().Contains(keyword.ToLower()));
            }
            return subnets1;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            //listreuslt = page.Get_AllTrip();
            Search.ItemsSource = null;
           // _count = listreuslt.Count();
            Quantity.Text = "Có " + _count + " kết quả được tìm thấy";

        }

        private void BtnJourney_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
