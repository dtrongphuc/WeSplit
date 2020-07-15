using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WeSplit.Models;

namespace WeSplit.ViewModels
{
    public class DetailViewModel:Screen
    {
        public Trip HistoryTrip { get; set; }
        public BindableCollection<Location> Place { get; set; }
        public BindableCollection<ReceiptsAndExpenses> Expenditures { get; set; }
        public SeriesCollection ChartData { get; set; }
        public BindableCollection<Images> ImageCarousel { get; set; }
        public BindableCollection<ReceiptsAndExpenses> MemberData { get; set; }
        GetListObject list = new GetListObject();

        public DetailViewModel(Trip trip)
        {
           //danh sách các chuyển đã đi
            HistoryTrip = trip;
            //các địa điểm của chuyến đi đó
            Place = list.Get_AllLocationTrip(trip.TripID);
            Expenditures = list.Get_AllReceAndExpenTrip(trip.TripID);

            ChartData = new SeriesCollection();
            foreach(ReceiptsAndExpenses element in Expenditures)
            {
                ChartValues<double> cost = new ChartValues<double>();
                cost.Add(Convert.ToDouble(element.Cost));
                PieSeries series = new PieSeries
                {
                    Values = cost,
                    Title = element.ExpensesName
                };
                ChartData.Add(series);
            }
            //hình ảnh của chuyển đi đó
            ImageCarousel = list.Get_AllImagesTrip(trip.TripID);
            GetListMemberData(trip.TripID);
        }

        public void GetListMemberData(string id)
        {
            MemberData = list.Get_AllReceAndExpenTrip(id);
        }
    }
}
