using System;
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

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tournament t = new Tournament(1, "test");
            t.Play();

           
            textBlockOpponents.Text = "";

            foreach (Schedule s in t.GetSchedules())
            {
                foreach (Match m in s.getMatchsList())
                {
                    // Ajoutez les adversaires à la TextBlock
                    textBlockOpponents.Text += $"Opponents 1: {m.getOpponents1()}\n";
                    textBlockOpponents.Text += $"Opponents 2: {m.getOpponents2()}\n";
                    textBlockOpponents.Text += "--------------------------------\n";
                }
            }
        }
    }
}
