﻿using System;
using Caliburn.Micro;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Dynamic;

namespace WeSplit.Models
{
    public class GetListObject : INotifyPropertyChanged
    {
        private string sql;
        private BindableCollection<Trip> _ListTripWasGone { get; set; } = new BindableCollection<Trip>();
        public BindableCollection<Trip> ListTripWasGone
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

        //private dynamic _customJourney = new ExpandoObject();
        //public dynamic CustomJourney
        //{
        //    get
        //    {
        //        return _customJourney;
        //    }
        //    set
        //    {
        //        _customJourney = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CustomJourney"));
        //    }
        //}

        private BindableCollection<Member> _ListMemberTrip { get; set; } = new BindableCollection<Member>();
        public BindableCollection<Member> ListMemberTrip
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

        private BindableCollection<Location> _ListLocation { get; set; } = new BindableCollection<Location>();
        public BindableCollection<Location> ListLocation
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

        private BindableCollection<ReceiptsAndExpenses> _ListReceAndExpen { get; set; } = new BindableCollection<ReceiptsAndExpenses>();
        public BindableCollection<ReceiptsAndExpenses> ListReceAndExpen
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

        private BindableCollection<ReceiptsAndExpenses> _listReceName { get; set; } = new BindableCollection<ReceiptsAndExpenses>();
        public BindableCollection<ReceiptsAndExpenses> ListReceName
        {
            get
            {
                return _listReceName;
            }
            set
            {
                _listReceName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListReceName"));
            }
        }

        private BindableCollection<Images> _ListImages { get; set; } = new BindableCollection<Images>();
        public BindableCollection<Images> ListImages
        {
            get
            {
                return _ListImages;
            }
            set
            {
                _ListImages = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListImages"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public ExpandoObject Get_JourneyCustom(string id)
        {
            dynamic CustomJourney = new ExpandoObject();
            Random r = new Random();
            Get_AllImagesTrip(id);
            Trip trip = new Trip();
            trip.Find(id);
            CustomJourney.TripID = trip.TripID;
            CustomJourney.TripName = trip.TripName;
            CustomJourney.Status = trip.Status;
            CustomJourney.StartDate = trip.StartDate;
            CustomJourney.MemberName = trip.MemberName;
            CustomJourney.Lenght = trip.Lenght;
            CustomJourney.EndDate = trip.EndDate;
            CustomJourney.Amount = trip.Amount;
            CustomJourney.Image = _ListImages[r.Next(0, _ListImages.Count())].Image;
            return CustomJourney;
        }

        public BindableCollection<Trip> Get_AllTripWasGone()
        {
            ListTripWasGone.Clear();
            sql = $"SELECT CD.*,TV.HOTEN FROM CHUYENDI AS CD JOIN THANHVIEN AS TV ON CD.MACD = TV.MACD WHERE CD.TRANGTHAI=0 AND TV.TRANGTHAI=1 ";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                Trip trip = new Trip();
                trip.TripID = row["MACD"].ToString();
                trip.TripName = row["TENCD"].ToString();
                trip.Status = (int)row["TRANGTHAI"];
                trip.Lenght = row["DODAI"].ToString();
                string dateStart = row["NGAYDI"].ToString();
                if (dateStart != "")
                {
                    var date = DateTime.Parse(dateStart);
                    trip.StartDate = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                string dateEnd = row["NGAYKT"].ToString();
                if (dateEnd != "")
                {
                    var date = DateTime.Parse(dateEnd);
                    trip.EndDate = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                trip.MemberName = row["HOTEN"].ToString();
                ListTripWasGone.Add(trip);
            }
            return ListTripWasGone;
        }

        public BindableCollection<Trip> Get_AllTrip()
        {
            ListTripWasGone.Clear();
            sql = $"SELECT * FROM CHUYENDI AS CD ";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                Trip trip = new Trip();
                trip.Amount++;
                trip.TripID = row["MACD"].ToString();
                trip.TripName = row["TENCD"].ToString();
                trip.Status = (int)row["TRANGTHAI"];
                trip.Lenght = row["DODAI"].ToString();
                trip.StartDate = row["NGAYDI"].ToString();
                trip.EndDate = row["NGAYKT"].ToString();
                ListTripWasGone.Add(trip);
            }
            return ListTripWasGone;
        }

        public BindableCollection<Location> Get_AllLocationTrip(string id)
        {
            ListLocation.Clear();
            sql = $"SELECT * FROM DIADIEM WHERE MACD = {id}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                Location location = new Location();
                location.LocationID = row["MADD"].ToString();
                location.TripID = row["MACD"].ToString();
                location.Number = row["STT"].ToString();
                location.LocationName = row["TENDD"].ToString();
                ListLocation.Add(location);
            }
            return ListLocation;
        }

        public BindableCollection<Location> Get_AllLocation()
        {
            ListLocation.Clear();
            sql = $"SELECT * FROM DIADIEM";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                Location location = new Location();
                location.LocationID = row["MADD"].ToString();
                location.TripID = row["MACD"].ToString();
                location.Number = row["STT"].ToString();
                location.LocationName = row["TENDD"].ToString();
                ListLocation.Add(location);
            }
            return ListLocation;
        }

        public BindableCollection<Member> Get_AllMemberTrip(string id)
        {
            ListMemberTrip.Clear();
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
                ListMemberTrip.Add(member);
            }
            return ListMemberTrip;
        }

        public BindableCollection<Member> Get_AllMember()
        {
            ListMemberTrip.Clear();
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
                ListMemberTrip.Add(member);
            }
            return ListMemberTrip;
        }

        public BindableCollection<ReceiptsAndExpenses> Get_AllReceAndExpenTrip(string ID)
        {
            ListReceAndExpen.Clear();
            sql = $"SELECT TV.MACD,TV.MATV,TV.HOTEN,TV.SDT,TC.TENKHOANCHI,TC.TIEN FROM THANHVIEN AS TV LEFT JOIN THUCHI AS TC ON TV.MATV=TC.MATV AND TV.MACD = TC.MACD WHERE TV.MACD={ID} ";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                ReceiptsAndExpenses RAE = new ReceiptsAndExpenses();
                RAE.TripID = row["MACD"].ToString();
                RAE.MemberID = row["MATV"].ToString();
                RAE.MemberName = row["HOTEN"].ToString();
                RAE.Telephone = row["SDT"].ToString();
                RAE.ExpensesName = row["TENKHOANCHI"].ToString();
                string cost = row["TIEN"].ToString();
                RAE.Cost = 0;
                if(cost != "")
                {
                    RAE.Cost = Double.Parse(cost, System.Globalization.NumberStyles.Any);
                }
                ListReceAndExpen.Add(RAE);
            }
            return ListReceAndExpen;
        }

        public BindableCollection<ReceiptsAndExpenses> Get_AllReceName(string ID)
        {
            ListReceName.Clear();
            sql = $"SELECT * FROM THUCHI WHERE MACD={ID} ";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                ReceiptsAndExpenses RAE = new ReceiptsAndExpenses();
                RAE.TripID = row["MACD"].ToString();
                RAE.ExpensesName = row["TENKHOANCHI"].ToString();
                string cost = row["TIEN"].ToString();
                RAE.Cost = 0;
                if (cost != "")
                {
                    RAE.Cost = Double.Parse(cost, System.Globalization.NumberStyles.Any);
                }
                ListReceName.Add(RAE);
            }
            return ListReceName;
        }

        public BindableCollection<Images> Get_AllImagesTrip(string ID)
        {
            ListImages.Clear();
            sql=$"SELECT * FROM HINHANH WHERE MACD = {ID}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                Images image = new Images();
                image.TripID = row["MACD"].ToString();
                image.Image = row["HINHANH"].ToString();
                ListImages.Add(image);
            }
            return ListImages;
        }

    }
}
