using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSplit.Models;
using WeSplit.Views;

namespace WeSplit.ViewModels
{
    class SearchViewModel:Screen
    {
        public SearchViewModel()
        {
        }

        public IEnumerable<Member> list1;
        public IEnumerable<Location> list;
        public IEnumerable<Location> subnets;
        public IEnumerable<Member> subnets1;
        public BindableCollection<ExpandoObject> Search { get; set; } = new BindableCollection<ExpandoObject>(); //list chứa kết quả cuối cùng.
        private string _info = "Tìm kiếm theo tên thành viên, tên địa điểm";
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
                NotifyOfPropertyChange(() => Info);
            }
        }
        public int _count = 0;
        string keysearchtext = null;
        GetListObject GetList = new GetListObject();

        private bool checkList(BindableCollection<ExpandoObject> list, dynamic trip)
        {
            foreach(ExpandoObject temp in list)
            {
                if (temp.GetValueOrDefault("TripID") == trip.TripID)
                    return true;
            }
            return false;
        }

        //từ tìm kiếm lưu trong "keysearchtext"
        public void BtnSearch()
        {
            
            keysearchtext = SearchView.Instance.SearchBox.Text.Trim();
            list = search_keywordLocation(keysearchtext);
            list1 = search_keywordMember(keysearchtext);
            for (int i=0;i<list.Count();i++)
            {
                var temp = list.ElementAt(i);
            }
            for (int i = 0; i < list1.Count(); i++)
            {
                var temp = list1.ElementAt(i);
            }
            if (keysearchtext == "")
            {
                return;
            }
            if (list.Count() != 0)
            {
                List<string> TripsID = new List<string>();
                foreach (var item in list1)
                {
                    if (!TripsID.Contains(item.TripID))
                    {
                        TripsID.Add(item.TripID);
                        dynamic trip = GetList.Get_JourneyCustom(item.TripID);
                        Search.Add(trip);
                    }
                }
                _count = Search.Count();
            }
            else if (list1.Count() != 0)
            {
                
                List<string> TripsID = new List<string>();
                foreach(var item in list1)
                {
                   if(!TripsID.Contains(item.TripID))
                    {
                        TripsID.Add(item.TripID);
                        dynamic trip = GetList.Get_JourneyCustom(item.TripID);
                        Search.Add(trip);
                    }
                }
                _count = Search.Count();
            }
            else
            {
                Search = null;
            }
            Info = "Có " + _count + " kết quả được tìm thấy";
        }

        //tìm kiếm theo dia diem chuyến đi 
        public IEnumerable<Location> search_keywordLocation(string keyword)
        {
            BindableCollection<Location> location = GetList.Get_AllLocation();

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
            BindableCollection<Member> member = GetList.Get_AllMember();

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

        public void ShowDetail(ExpandoObject tripSelected)
        {
            dynamic temp = tripSelected;
            string id = temp.TripID;
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            parentConductor.ActivateItem(new DetailViewModel(id));
        }
    }
}
