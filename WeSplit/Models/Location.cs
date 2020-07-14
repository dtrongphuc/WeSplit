using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSplit.Models
{
    public class Location : INotifyPropertyChanged
    {
        private string _LocationID;
        public string LocationID
        {
            get { return _LocationID; }
            set
            {
                _LocationID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LocationID"));
            }
        }

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

        private string _Number;
        public string Number
        {
            get { return _Number; }
            set
            {
                _Number = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
            }
        }

        private string _LocationName;
        public string LocationName
        {
            get { return _LocationName; }
            set
            {
                _LocationName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LocationName"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Location()
        {
            this._TripID = "";
            this._Number = "";
            this._LocationName = "";
            this._LocationID = "";            
        }

        string sql;
        public void Add()
        {
            sql = $"INSER INTO DIADIEM VALUES (MADD = {_LocationID}, MACD={_TripID}, STT ={_Number}, TENDD=N'{_LocationName}')";
            Connection.Execute_SQL(sql);
        }

        public void Edit()
        {
            sql = $"UPDATE DIADIEM SET MACD={_TripID}, STT ={_Number}, TENDD=N'{_LocationName}' WHERE MADD = {_LocationID}";
            Connection.Execute_SQL(sql);
        }

        public void Delete()
        {
            sql = $"DELETE FROM DIADIEM WHERE MATV ={_LocationID}";
            Connection.Execute_SQL(sql);
        }
    }
}
