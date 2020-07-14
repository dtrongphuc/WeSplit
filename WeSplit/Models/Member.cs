using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSplit.Models
{
    public class Member : INotifyPropertyChanged
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

        private string _MemberID;
        public string MemberID
        {
            get { return _MemberID; }
            set
            {
                _MemberID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MemberID"));
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

        private string _Diary;
        public string Diary
        {
            get { return _Diary; }
            set
            {
                _Diary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Diary"));
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

        private string _Telephone;
        public string Telephone
        {
            get { return _Telephone; }
            set
            {
                _Telephone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Telephone"));
            }
        }

      
        public event PropertyChangedEventHandler PropertyChanged;

        public Member()
        {
            this._TripID = "";
            this._Telephone = "";
            this._Status=0;
            this._MemberName = "";
            this._MemberID = "";
            this._Diary = "";
        }

        string sql;
        public void Add()
        {
            sql = $"SELECT IDENT_CURRENT('CHUYENDI') AS SOLUONG";
            _TripID = Connection.GetCount_Data(sql).ToString();
             sql = $"INSERT INTO THANHVIEN VALUES ( MACD = {_TripID}, HOTEN =N'{_MemberName}', NHATKY =N'{_Diary}', SDT='{_Telephone}', TRANGTHAI={_Status})";
            Connection.Execute_SQL(sql);
        }

        public void Edit()
        {
             sql = $"UPDATE THANHVIEN  SET MACD = {_TripID}, HOTEN =N'{_MemberName}',  NHATKY =N'{_Diary}', SDT='{_Telephone}', TRANGTHAI={_Status}  WHERE MATV ={_MemberID}";
            Connection.Execute_SQL(sql);
        }

        public void Delete()
        {
            sql = $"DELETE FROM THANHVIEN WHERE MATV ={_MemberID} ";
            Connection.Execute_SQL(sql);
        }

        public void Leader(string id)
        {
            sql = $"SELECT * FROM THANHVIEN WHERE MACD={id} AND TRANGTHAI=1";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                _MemberID = row["MATV"].ToString();
                _TripID = row["MACD"].ToString();
                _MemberName = row["HOTEN"].ToString();
                _Diary = row["NHATKY"].ToString();
                _Telephone = row["SDT"].ToString();
                _Status = (int)row["TRANGTHAI"];
              
            }
        }
    }
}
