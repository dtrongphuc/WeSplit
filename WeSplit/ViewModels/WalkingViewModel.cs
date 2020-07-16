using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WeSplit.Models;
using WeSplit.ViewModels;

namespace WeSplit.ViewModels
{
    public class WalkingViewModel:Screen
    {
        private Trip _journeyInfo = new Trip();
        public Trip JourneyInfo
        {
            get
            {
                return _journeyInfo;
            }
            set
            {
                _journeyInfo = value;
                NotifyOfPropertyChange(() => JourneyInfo);
            }
        }

        public WalkingViewModel()
        {
            JourneyInfo.TripIsGoing();
            HistoryViewModel.list.Get_AllTripWasGone();
        }

        public void EndJourneyClick()
        {
            JourneyInfo.Status = 0; // Đặt trạng thái thành đã đi
            // Xử lý database chỗ này
        }
    }
}
