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

namespace WeSplit.Views
{
    /// <summary>
    /// Interaction logic for AddJourneyView.xaml
    /// </summary>
    public partial class AddJourneyView : UserControl
    {
        public AddJourneyView()
        {
            InitializeComponent();
            StartDay.SelectedDate = DateTime.Today;
            EndDay.SelectedDate = DateTime.Now.AddDays(1);
        }

        private void BtnAddAvatar(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddIngredientsField_Click(object sender, RoutedEventArgs e)
        {
            Style style = this.FindResource("UserNameBox") as Style;
            var newTextbox = new TextBox();
            newTextbox.Style = style;
            Ingredients.Children.Add(newTextbox);
        }

        private void BtnAddStepField_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
