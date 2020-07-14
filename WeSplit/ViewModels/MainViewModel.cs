﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSplit.Views;
using static WeSplit.Views.HistoryView;

namespace WeSplit.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive, INotifyPropertyChanged
    {
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

        public WalkingViewModel WalkingViewModel
        {
            get; set;
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
            if(ActiveItem == null)
            {
                return;
            }
            ActiveItem.TryClose();
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
            WhoActived = "Add";
            CloseCurrentView();
            ActivateItem(new AddJourneyViewModel());
            DisplayName = "Tạo chuyến đi";
        }

        public void UpdateClick()
        {
            WhoActived = "Update";
            CloseCurrentView();
            ActivateItem(new UpdateJourneyViewModel());
            DisplayName = "Cập nhật chuyến đi";
        }

        public void ShowHistoryView()
        {
            HistoryViewModel = new HistoryViewModel();
            HistoryViewModel.Refresh();
            HistoryViewModel.Parent = this;
        }

        public void CloseCurrentView()
        {
            if(Items.Count > 0)
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
