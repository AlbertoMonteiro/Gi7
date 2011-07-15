﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using Github7.Utils.Messages;
using Github7.Service;

namespace Github7.Views
{
    public partial class HomeView : PhoneApplicationPage
    {
        public HomeView()
        {
            Messenger.Default.Register<PanelMessage>(this, "homeAdd", p =>
            {
                Panorama.Items.Add(
                    new PanoramaItem(){
                        Content = Activator.CreateInstance(p.ViewType),
                        Header = p.Header
                    });
            });

            Messenger.Default.Register<bool>(this, "clearHome", p =>
            {
                Panorama.Items.Clear();
            });

            InitializeComponent();

            DataContext = new ViewModelLocator().HomeViewModel;
        }
    }
}