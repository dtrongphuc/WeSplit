using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSplit.Views;
using WeSplit.Models;
using static WeSplit.Views.HistoryView;
using System.ComponentModel.Composition;
using System.Windows.Data;

namespace WeSplit.ViewModels
{
    public class HistoryViewModel:Screen
    {
        private int _historywidth = 0;
        private int _canvasheight = 520;
        private bool _isLocatedDetail = false;

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

        public bool IsLocatedDetail
        {
            get { return _isLocatedDetail; }
            set
            {
                _isLocatedDetail = value;
                NotifyOfPropertyChange(() => IsLocatedDetail);
            }
        }

        public HistoryViewModel()
        {
            JourneyHistory = new BindableCollection<Trip>
            {
                new Trip { TripName = "Tên chuyến đi 1" },
                new Trip { TripName = "Tên chuyến đi 2" },
                new Trip { TripName = "Tên chuyến đi 3" },
            };
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        public void ShowDetail()
        {
            IsLocatedDetail = true;
            isLocatedDetail = IsLocatedDetail;
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            parentConductor.ActivateItem(new DetailViewModel());
        }
    }
}
