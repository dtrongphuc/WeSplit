using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSplit.Models
{
    class GetListObject : INotifyPropertyChanged
    {
        private string sql;
        private BindingList<Trip> _ListTripWasGone { get; set; } = new BindingList<Trip>();
        public BindingList<Trip> ListTripWasGone
        {
            get
            {
                return _ListTripWasGone;
            }
            set
            {
                _ListTripWasGone = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListTripWasGone"));
            }
        }

        private BindingList<Member> _ListMemberTrip { get; set; } = new BindingList<Member>();
        public BindingList<Member> ListMemberTrip
        {
            get
            {
                return _ListMemberTrip;
            }
            set
            {
                _ListMemberTrip = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListMemberTrip"));
            }
        }

        private BindingList<Location> _ListLocation { get; set; } = new BindingList<Location>();
        public BindingList<Location> ListLocation
        {
            get
            {
                return _ListLocation;
            }
            set
            {
                _ListLocation = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListLocation"));
            }
        }

        private BindingList<ReceiptsAndExpenses> _ListReceAndExpen { get; set; } = new BindingList<ReceiptsAndExpenses>();
        public BindingList<ReceiptsAndExpenses> ListReceAndExpen
        {
            get
            {
                return _ListReceAndExpen;
            }
            set
            {
                _ListReceAndExpen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListReceAndExpen"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public BindingList<Trip> Get_AllTripWasGone()
        {
            ListTripWasGone.Clear();
            sql = $"SELECT * FROM CHUYENDI WHERE TRANGTHAI = 0";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                Trip trip = new Trip();
                trip.TripID = row["MACD"].ToString();
                trip.TripName = row["TENCD"].ToString();
                trip.Status = (int)row["TRANGTHAI"];
                trip.Lenght = row["DODAI"].ToString();
                trip.StartDate = row["NGAYDI"].ToString();
                trip.EndDate = row["NGAYKT"].ToString();
                _ListTripWasGone.Add(trip);
            }
            return ListTripWasGone;
        }

        public BindingList<Location> Get_AllLocationTrip(string id)
        {
            _ListLocation.Clear();
            sql = $"SELECT * FROM DIADIEM WHERE MACD = {id}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                Location location = new Location();
                location.LocationID = row["MADD"].ToString();
                location.TripID = row["MACD"].ToString();
                location.Number = row["STT"].ToString();
                location.LocationName = row["TENDD"].ToString();
                _ListLocation.Add(location);
            }
            return _ListLocation;
        }

        public  BindingList<Location> Get_AllLocation()
        {
            _ListLocation.Clear();
            sql = $"SELECT * FROM DIADIEM";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                Location location = new Location();
                location.LocationID = row["MADD"].ToString();
                location.TripID = row["MACD"].ToString();
                location.Number = row["STT"].ToString();
                location.LocationName = row["TENDD"].ToString();
                _ListLocation.Add(location);
            }
            return _ListLocation;
        }

        public BindingList<Member> Get_AllMemberTrip(string id)
        {
            _ListMemberTrip.Clear();
            sql = $"SELECT * FROM THANHVIEN where MACD ={id}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                Member member = new Member();
                member.MemberID = row["MATV"].ToString();
                member.TripID = row["MACD"].ToString();
                member.MemberName = row["HOTEN"].ToString();
                member.Diary = row["NHATKY"].ToString();
                member.Telephone = row["SDT"].ToString();
                member.Status = (int)row["TRANGTHAI"];
                member.Contributie = row["DONGGOP"].ToString();
                _ListMemberTrip.Add(member);
            }
            return _ListMemberTrip;
        }

        public BindingList<Member> Get_AllMember()
        {
            _ListMemberTrip.Clear();
            sql = $"SELECT * FROM THANHVIEN";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                Member member = new Member();
                member.MemberID = row["MATV"].ToString();
                member.TripID = row["MACD"].ToString();
                member.MemberName = row["HOTEN"].ToString();
                member.Diary = row["NHATKY"].ToString();
                member.Telephone = row["SDT"].ToString();
                member.Status = (int)row["TRANGTHAI"];
                member.Contributie = row["DONGGOP"].ToString();
                _ListMemberTrip.Add(member);
            }
            return _ListMemberTrip;
        }

        public BindingList<ReceiptsAndExpenses> Get_AllReceAndExpenTrip(string ID)
        {
            _ListReceAndExpen.Clear();
            sql = $"SELECT * FROM THUCHI WHERE MACD ={ID} ";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                ReceiptsAndExpenses RAE = new ReceiptsAndExpenses();
                RAE.TripID = row["MACD"].ToString();
                RAE.ExpensesName = row["TENKHOANCHI"].ToString();
                RAE.Cost = row["TIEN"].ToString();
                _ListReceAndExpen.Add(RAE);
            }
            return _ListReceAndExpen;
        }

    }
}
