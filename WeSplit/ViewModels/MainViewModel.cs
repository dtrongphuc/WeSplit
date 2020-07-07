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
        public MainViewModel()
        {
            ShowHomeView();
        }

        public void ShowHomeView()
        {
            ActivateItem(new HomeViewModel());
        }
    }
}
