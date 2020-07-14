using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
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
        public BindableCollection<ReceiptsAndExpenses> Expenditures { get; set; }
        public SeriesCollection ChartData { get; set; }
        GetListObject list = new GetListObject();

        public DetailViewModel(Trip trip)
        {
            HistoryTrip = trip;
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
        }
    }
}
