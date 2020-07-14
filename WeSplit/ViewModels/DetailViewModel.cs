using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSplit.Models;

namespace WeSplit.ViewModels
{
    public class DetailViewModel:Screen
    {
        public Trip HistoryTrip { get; set; }
        public BindableCollection<Location> Place { get; set; }
        GetListObject list = new GetListObject();
        public DetailViewModel(Trip trip)
        {
           
            HistoryTrip = trip;
            Place = list.Get_AllLocationTrip(trip.TripID);
        }
    }
}
