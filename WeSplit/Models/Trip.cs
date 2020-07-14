﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSplit.Models
{
    public class Trip: INotifyPropertyChanged
    {
       
            private string _TripID;
            public string TripID
            {
                get { return _TripID; }
                set
                {
                    _TripID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TripID"));
                }
            }

            private string _TripName;
            public string TripName
            {
                get { return _TripName; }
                set
                {
                    _TripName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TripName"));
                }
            }

            private int _Status;
            public int Status
            {
                get { return _Status; }
                set
                {
                    _Status = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
                }
            }

            private string _StartDate;
            public string StartDate
            {
                get { return _StartDate; }
                set
                {
                    _StartDate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartDate"));
                }
            }

            private string _EndDate;
            public string EndDate
            {
                get { return _EndDate; }
                set
                {
                    _EndDate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EndDate"));
                }
            }

            private string _Lenght;
            public string Lenght
            {
                get { return _Lenght; }
                set
                {
                    _Lenght = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lenght"));
                }
            }

        private string _MemberName;
        public string MemberName
        {
            get { return _MemberName; }
            set
            {
                _MemberName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MemberName"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

            
        public Trip()
        {
            this._TripID = "";
            this._TripName = "";
            this._Status = 1;
            this._StartDate = "";
            this._Lenght = "";
            this._EndDate = "";
            _MemberName = "";
        }

        string sql;
        public void Add()
        {
            sql = $"UPDATE CHUYENDI SET TRANGTHAI = 0 ";
            Connection.Execute_SQL(sql);
            sql = $"INSERT INTO CHUYENDI VALUES ( N'{_TripName}', {_Status}, N'{_StartDate}', N'{_EndDate}', {_Lenght})";
            Connection.Execute_SQL(sql);
        }

        public void Edit()
        {
          sql = $"UPDATE CHUYENDI SET  TENCD =N'{_TripName}', TRANGTHAI ={_Status}, NGAYDI=N'{_StartDate}', NGAYKT=N'{_EndDate}', DODAI={_Lenght} WHERE MACD ={_TripID} ";
            Connection.Execute_SQL(sql);
        }

        public void TripIsGoing()
        {
            sql = $"SELECT CD.*,TV.HOTEN FROM CHUYENDI AS CD JOIN THANHVIEN AS TV ON CD.MACD = TV.MACD WHERE CD.TRANGTHAI=1 AND TV.TRANGTHAI=1";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
               
                this.TripID = row["MACD"].ToString();
                this.TripName = row["TENCD"].ToString();
                this.Status = (int)row["TRANGTHAI"];
                this.Lenght = row["DODAI"].ToString();
                this.StartDate = row["NGAYDI"].ToString();
                this.EndDate = row["NGAYKT"].ToString();
                this.MemberName = row["HOTEN"].ToString();  
            }
        }
    }
}
