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
        public BindableCollection<Images> ImageCarousel { get; set; }
        GetListObject list = new GetListObject();
        public DetailViewModel(Trip trip)
        {
           //danh sách các chuyển đã đi
            HistoryTrip = trip;
            //các địa điểm của chuyến đi đó
            Place = list.Get_AllLocationTrip(trip.TripID);
            //hình ảnh của chuyển đi đó
            ImageCarousel = list.Get_AllImagesTrip(trip.TripID);
        }
    }
}
