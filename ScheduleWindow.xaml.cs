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
using System.Windows.Shapes;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    /// <summary>
    /// Logique d'interaction pour ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        

        public ScheduleWindow()
        {
            InitializeComponent();
            
            
        }
        
        public ItemsControl MatchItemControl
        {
            get { return matchesItemsControl; }
        }
        public string TitleText
        {
            get { return scheduleTitleTextBlock.Text; }
            set { scheduleTitleTextBlock.Text = value; }
        }


    }
}
