﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WeSplit.Models;
using WeSplit.ViewModels;
using System.Windows.Controls;
namespace WeSplit.ViewModels
{
    public class WalkingViewModel:Screen
    {
        private Trip _journeyInfo;
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
            Trip trip = new Trip();
            JourneyInfo = trip.GetTripGoing();
        }

        public void EndJourneyClick()
        {
            JourneyInfo.Status = 0; // Đặt trạng thái thành đã đi
            DateTime now = DateTime.Now;
            JourneyInfo.EndDate = $"{now.Month}/{now.Day}/{now.Year}";
            JourneyInfo.EndTrip();
            HistoryViewModel.list.Get_AllTripWasGone();
        }

        public void ShowDetail()
        {
            var parentConductor = (Conductor<IScreen>.Collection.OneActive)(this.Parent);
            parentConductor.ActivateItem(new DetailViewModel(JourneyInfo.TripID));
        }
    }
}
