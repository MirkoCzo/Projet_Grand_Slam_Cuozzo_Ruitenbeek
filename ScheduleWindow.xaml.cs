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

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public ComboBox ComboBoxMatches
        {
            get { return comboBoxMatches; }
        }
    }
}
