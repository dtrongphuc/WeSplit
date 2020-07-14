using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSplit.Models
{
    public class Images : INotifyPropertyChanged
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

        private string _Image;
        public string Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Image"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Images()
        {
            _TripID = "";
            _Image = "/Resource/Images/trip.jpg";
        }

        string sql;
        public void Add()
        {
            sql = $"INSERT INTO HINHANH VALUES(MACD = {_TripID}, HINHANH='{_Image}')";
            Connection.Execute_SQL(sql);
        }

        public void Edit()
        {
            sql = $"UPDATE HINHANH SET HINHANH='{_Image}' WHERE MACD = {_TripID}";
            Connection.Execute_SQL(sql);
        }

        public void Delete()
        {
            sql = $"DELETE FROM HINHANH WHERE MACD = {_TripID} ";
            Connection.Execute_SQL(sql);
        }
    }
}
