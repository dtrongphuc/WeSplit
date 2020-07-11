using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSplit.Models
{
    class Trip: INotifyPropertyChanged
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
            public event PropertyChangedEventHandler PropertyChanged;

            
        public Trip()
        {
            this._TripID = "";
            this._TripName = "";
            this._Status = 0;
            this._StartDate = "";
            this._Lenght = "";
            this._EndDate = "";
        }

        public void Add()
        {
            string sql;
            sql = $"INSERT INTO CHUYENDI VALUES ({_TripID}, N'{_TripName}', {_Status}, N'{_StartDate}', N'{_EndDate}', {_Lenght})";
            Connection.Execute_SQL(sql);
        }

        public void Edit()
        {
            string sql = $"UPDATE CHUYENDI SET  TENCD =N'{_TripName}', TRANGTHAI ={_Status}, NGAYDI=N'{_StartDate}', NGAYKT=N'{_EndDate}', DODAI={_Lenght} WHERE MACD ={_TripID} ";
            Connection.Execute_SQL(sql);
        }
    }
}
