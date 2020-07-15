using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeSplit.Models;

namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public IEnumerable<Trip> list;
        public IEnumerable<Trip> subnets;
        public int _count=0;
        GetListObject page = new GetListObject();
        public SearchView()
        {

            InitializeComponent();
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        string keysearchtext = null;

        public object CategoryList { get; private set; }

        //từ tìm kiếm lưu trong "keysearchtext"
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {            
            keysearchtext = SearchBox.Text.Trim();
            
            if (keysearchtext != "")
            {
                list = search_keyword(keysearchtext);
                UpdateQuantity();
            }
        }

        //tìm kiếm theo tên chuyến đi 
        public IEnumerable<Trip> search_keyword(string keyword)
        {
            BindableCollection<Trip> trip = page.Get_AllTripWasGone();

            if (keyword == "")
            {
                ProductsSearch.ItemsSource = trip;
            }
            else
            {
                subnets = trip.Where(i => i.TripName.ToLower().Contains(keyword.ToLower()));
            }
            return subnets;
        }

        //số kết quả 
        private void UpdateQuantity()
        {
            _count = list.Count();
            Quantity.Text = "Có " + _count + " kết quả được tìm thấy";
            ProductsSearch.ItemsSource = list;
        }
    }
}
