using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WeSplit.Models;

namespace WeSplit.ViewModels
{
    public class DetailViewModel:Screen
    {
        public string CarouselItemCount { get; set; }
        public int MemberCount { get; set; } = 0;
        public double TotalRevenue { get; set; } = 0;
        public double TotalRevenueOfMember{ get; set; } = 0;

        public Trip HistoryTrip { get; set; }
        public BindableCollection<Location> Place { get; set; }
        public SeriesCollection ChartData { get; set; }
        public BindableCollection<Images> ImageCarousel { get; set; }
        public BindableCollection<ReceiptsAndExpenses> MemberData { get; set; }
        public BindableCollection<Member> MemberOfTrip { get; set; }
        public BindableCollection<ExpandoObject> MoneySplit { get; set; }

        GetListObject list = new GetListObject();

        public DetailViewModel(Trip trip)
        {
           //danh sách các chuyển đã đi
            HistoryTrip = trip;
            //các địa điểm của chuyến đi đó
            Place = list.Get_AllLocationTrip(trip.TripID);
            //hình ảnh của chuyển đi đó
            ImageCarousel = list.Get_AllImagesTrip(trip.TripID);
            CarouselItemCount = ImageCarousel.Count.ToString();
            MemberOfTrip = list.Get_AllMemberTrip(trip.TripID);
            MemberCount = MemberOfTrip.Count;
            GetListMemberData(trip.TripID);
            TotalRevenueOfMember = 1.0*TotalRevenue / MemberCount;
            MoneySplit = CreateMoneySplitObject(MemberOfTrip, MemberData);
        }

        public void GetListMemberData(string id)
        {
            MemberData = list.Get_AllReceAndExpenTrip(id);

            ChartData = new SeriesCollection();
            foreach (ReceiptsAndExpenses element in MemberData)
            {
                TotalRevenue += element.Cost;

                ChartValues<double> cost = new ChartValues<double>();
                if(element.Cost > 0)
                {
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

        public BindableCollection<ExpandoObject> CreateMoneySplitObject(BindableCollection<Member> members, BindableCollection<ReceiptsAndExpenses> moneydata)
        {
            BindableCollection<ExpandoObject> list = new BindableCollection<ExpandoObject>();
            var moneyDataGroup = moneydata.GroupBy(i => i.MemberID);

            foreach (var member in members)
            {
                dynamic obj = new ExpandoObject();
                obj.MemberName = member.MemberName;
                double TotalCost = 0;
                foreach (var item in moneyDataGroup)
                {
                    if(item.Any(i => i.MemberID == member.MemberID))
                    {
                        var ToalCostCollection = item.Select(i => i.Cost);
                        foreach(var cost in ToalCostCollection)
                        {
                            TotalCost += cost;
                        }
                    }
                }
                double Cal = TotalCost - TotalRevenueOfMember;
                obj.Cost = String.Format("{0:#,#}", Cal);
                list.Add(obj);
            }
            return list;
        }
    }
}
