using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSplit.Models
{
    public class ReceiptsAndExpenses : INotifyPropertyChanged
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

        private string _ExpensesName;
        public string ExpensesName
        {
            get { return _ExpensesName; }
            set
            {
                _ExpensesName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ExpensesName"));
            }
        }

        private double _Cost;
        public double Cost
        {
            get { return _Cost; }
            set
            {
                _Cost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cost"));
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

        private string _telephone;
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Telephone"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ReceiptsAndExpenses()
        {
            this._Cost = 0;
            this._TripID = "NULL";
            this._ExpensesName = "NULL";
            this._MemberName = "NULL";
            this._MemberID = "NULL";
            this._telephone = "NULL";
        }

        string sql;
        public void Add()
        {
           
            sql = $"INSERT INTO THUCHI VALUES ( {_MemberID} ,{_TripID},  N'{_ExpensesName}',  {_Cost})";
            Connection.Execute_SQL(sql);
        }



        //public void EditExpen()
        //{
        //    sql = $"UPDATE THUCHI SET  TENKHOANCHI=N'{_ExpensesName}', TIEN=N'{_Cost}'  WHERE MACD ={_TripID}";
        //    Connection.Execute_SQL(sql);
        //}

        public void Edit()
        {
            sql = $"UPDATE THUCHI SET   TIEN=N'{_Cost}',  MATV = {_MemberID}  WHERE MACD ={_TripID} AND TENKHOANCHI=N'{_ExpensesName}'";
            Connection.Execute_SQL(sql);
        }

        public void Delete()
        {
            sql = $"DELETE FROM DIADIEM WHERE MACD ={_TripID} AND TENKHOANCHI=N'{_ExpensesName}'";
            Connection.Execute_SQL(sql);
        }

        public string SumRAE()
        {
            sql = $"SELECT SUM(*) AS 'TONG' FROM THUCHI WHERE MACD ={_TripID}";

            return Connection.GetCount_Data(sql);
        }
    }
}
