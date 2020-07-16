using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSplit.Views;
using WeSplit.Models;
using System.ComponentModel.Composition;
using System.Windows.Data;

namespace WeSplit.ViewModels
{
    public class HistoryViewModel:Screen
    {
        private int _historywidth = 0;
        private int _canvasheight = 520;

        public static GetListObject list = new GetListObject();

        public BindableCollection<Trip> JourneyHistory { get; set; }

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

        public int CanvasHeight
        {
            get
            {
                return _canvasheight;
            }
            set
            {
                _canvasheight = value;
                NotifyOfPropertyChange(() => CanvasHeight);
            }
        }

        public HistoryViewModel()
        {
            JourneyHistory = list.Get_AllTripWasGone();
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        public void ShowDetail(Trip tripSelected)
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            parentConductor.ActivateItem(new DetailViewModel(tripSelected));
        }
    }
}
