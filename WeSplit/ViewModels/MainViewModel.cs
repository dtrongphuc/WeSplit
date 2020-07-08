using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSplit.Views;


namespace WeSplit.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
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

        public void ShowHistoryView()
        {
            HistoryViewModel = new HistoryViewModel();
            HistoryViewModel.Parent = this;
            //ActivateItem(HistoryViewModel);
        }

        public void ShowWalkingView()
        {
            WalkingViewModel = new WalkingViewModel();
            WalkingViewModel.Parent = this;
            //ActivateItem(WalkingViewModel);
        }
    }
}
