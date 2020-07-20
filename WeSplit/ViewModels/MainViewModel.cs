using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeSplit.Models;
using WeSplit.Views;
using static WeSplit.Views.HistoryView;

namespace WeSplit.ViewModels
{
   
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive, INotifyPropertyChanged
    {
        private Trip TripGoing = new Trip();
        private HistoryViewModel _historyViewModel;
        public HistoryViewModel HistoryViewModel
        {
            get { return _historyViewModel; }
            set
            {
                _historyViewModel = value;
                NotifyOfPropertyChange(() => HistoryViewModel);
            }
        }

        private WalkingViewModel _walkingViewModel;
        public WalkingViewModel WalkingViewModel
        {
            get { return _walkingViewModel; }
            set
            {
                _walkingViewModel = value;
                NotifyOfPropertyChange(() => WalkingViewModel);
            }
        }

        private string _whoActived;
        public string WhoActived
        {
            get { return _whoActived; }
            set
            {
                _whoActived = value;
                NotifyOfPropertyChange(() => WhoActived);
            }
        }

        public MainViewModel()
        {
            DisplayName = "Trang chủ";
            WhoActived = "Home";
            ShowHistoryView();
            ShowWalkingView();
        }

        public void HomeClick()
        {
            if (ActiveItem == null)
            {
                return;
            }
            CloseCurrentView();
            isLocatedDetail = false;
            WhoActived = "Home";
            ShowHistoryView();
            ShowWalkingView();
            DisplayName = "Trang chủ";
        }

        public void SearchClick()
        {
            WhoActived = "Search";
            CloseCurrentView();
            ActivateItem(new SearchViewModel());
            DisplayName = "Tìm kiếm";
        }

        public void AddClick()
        {
            if(TripGoing.TripIsGoing())
            {
                MessageBox.Show("Đang có chuyến đang đi, không thể tạo mới", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                HomeClick();
                MainView.Instance.HistoryViewModel.Visibility = Visibility.Visible;
                return;
            }
            WhoActived = "Add";
            CloseCurrentView();
            ActivateItem(new AddJourneyViewModel());
            DisplayName = "Tạo chuyến đi";
        }

        public bool check()
        {
            if (TripGoing.TripIsGoing() == false)
                return false;
            return true;
        }

        public void UpdateClick()
        {
            if (check() == true)
            {
                WhoActived = "Update";
                CloseCurrentView();
                ActivateItem(new UpdateJourneyViewModel());
                DisplayName = "Cập nhật chuyến đi";
            }
            else
            {
                MessageBox.Show("Không có chuyến đang đi, không thể cập nhật", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                HomeClick();
                MainView.Instance.HistoryViewModel.Visibility = Visibility.Visible;
            }
        }

        public void ShowHistoryView()
        {
            HistoryViewModel = new HistoryViewModel();
            HistoryViewModel.Refresh();
            HistoryViewModel.Parent = this;
        }

        public void CloseCurrentView()
        {
            while (Items.Count > 0)
            {
                DeactivateItem(Items[0], true);
            }
        }

        public void ShowWalkingView()
        {
            WalkingViewModel = new WalkingViewModel();
            WalkingViewModel.Parent = this;
        }
    }
}
