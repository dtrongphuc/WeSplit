using Caliburn.Micro;
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
            CloseCurrentView();
            ActivateItem(new SearchViewModel());
        }

        public void AddClick()
        {
            CloseCurrentView();
            ActivateItem(new AddJourneyViewModel());
        }

        public void UpdateClick()
        {
            CloseCurrentView();
            ActivateItem(new UpdateJourneyViewModel());
        }

        public void ShowHistoryView()
        {
            HistoryViewModel = new HistoryViewModel();
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
