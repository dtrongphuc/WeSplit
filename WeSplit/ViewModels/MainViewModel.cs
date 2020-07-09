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
        public HistoryViewModel HistoryViewModel
        {
            get; set;
        }

        public WalkingViewModel WalkingViewModel
        {
            get; set;
        }

        public MainViewModel()
        {
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

            ShowHistoryView();
            ShowWalkingView();
        }

        public void SearchClick()
        {
            CloseHomeView();
            ActivateItem(new SearchViewModel());
        }

        public void ShowHistoryView()
        {
            HistoryViewModel = new HistoryViewModel();
            HistoryViewModel.Parent = this;
            //ActivateItem(HistoryViewModel);
        }

        public void CloseHomeView()
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
            //ActivateItem(WalkingViewModel);
        }
    }
}
