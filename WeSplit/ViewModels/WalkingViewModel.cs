using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeSplit.Models;

namespace WeSplit.ViewModels
{
    public class WalkingViewModel:Screen
    {
        public BindableCollection<Trip> JourneyInfo { get; set; }
        public WalkingViewModel()
        {
            JourneyInfo = new BindableCollection<Trip>
            {
                new Trip {TripName = "test" }
            };
            // tripisgoing tra ve 1 mang
        }
    }

}
