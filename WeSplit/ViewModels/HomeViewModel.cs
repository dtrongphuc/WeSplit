﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WeSplit.ViewModels
{
    public class HomeViewModel:Screen
    {
        private int _historywidth = 280;
        private int _canvasheight = 520;

        public int HistoryWidth
        {
            get
            {
                return _historywidth;
            }
            set
            {
                _historywidth = value;
                NotifyOfPropertyChange(() => HistoryWidth);
            }
        }

        public int CanvasHeight
        {
            get
            {
                return _canvasheight;
            }
            set
            {
                _canvasheight = value;
                NotifyOfPropertyChange(() => CanvasHeight);
            }
        }

        public HomeViewModel()
        {

        }
    }
}
