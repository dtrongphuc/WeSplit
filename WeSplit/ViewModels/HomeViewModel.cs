using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WeSplit.ViewModels
{
    public class HomeViewModel:Screen
    {
        private int _historywidth = 280;
        public int HistoryWidth
        {
            get
            {
                return _historywidth;
            }
            set
            {
                _historywidth = value;
                NotifyOfPropertyChange(() => HistoryWidth);
            }
        }
     
        public HomeViewModel()
        {

        }

        public void ShowToRight()
        {
            HistoryWidth = 400;
        }
    }
}
