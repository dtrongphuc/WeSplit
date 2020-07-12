using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeSplit.Models
{
    class ReceiptsAndExpenses : INotifyPropertyChanged
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

        private string _Cost;
        public string Cost
        {
            get { return _Cost; }
            set
            {
                _Cost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cost"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ReceiptsAndExpenses()
        {
            this._Cost = "";
            this._TripID = "";
            this._ExpensesName = "";
        }

        string sql;
        public void Add()
        {
            sql = $"INSERT INTO THUCHI VALUES (MACD ={_TripID}, TENKHOANCHI=N'{_ExpensesName}', TIEN=N'{_Cost}')";
            Connection.Execute_SQL(sql);
        }

        public void Edit()
        {
            sql = $"UPDATE THUCHI SET  TENKHOANCHI=N'{_ExpensesName}', TIEN=N'{_Cost}' WHERE MACD ={_TripID}";
            Connection.Execute_SQL(sql);
        }

        public void Delete()
        {
            sql = $"DELETE FROM DIADIEM WHERE MACD ={_TripID} AND TENKHOANCHI=N'{_ExpensesName}'";
            Connection.Execute_SQL(sql);
        }

        public int SumRAE()
        {
            sql = $"SELECT SUM(*) AS 'TONG' FROM THUCHI WHERE MACD ={_TripID}";

            return Connection.GetCount_Data(sql);
        }
    }
}
