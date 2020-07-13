﻿using System;
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
    /// Interaction logic for WalkingView.xaml
    /// </summary>
    public partial class WalkingView : UserControl
    {
        public WalkingView()
        {
            InitializeComponent();
        }

       

        private void WalkingView_Loaded(object sender, RoutedEventArgs e)
        {
            Trip trip = new Trip();
            trip.TripIsGoing();
            this.Content = trip;
        }
    }
}
