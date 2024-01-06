using Projet_Grand_Slam_Cuozzo_Ruitenbeek.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // MainWindow.xaml.cs
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tournament t = new Tournament("TestTournoi", new DateTime(2024, 1, 1));
            t.GenerateSchedules();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Schedule> scheduleList = t.GetSchedules();
            for (int i = 0; i < 7; i++)
            {
                scheduleList[1].PlayNextRound();

            }
            Queue<Opponents> w = scheduleList[1].GetOpponentsList();
            foreach (Opponents o in w)
            {
                MessageBox.Show(o.Player1.getLastname());
            }


            stopwatch.Stop();

           

            // Afficher le temps écoulé
            MessageBox.Show($"Temps écoulé : {stopwatch.Elapsed}");
        }

        /*
        foreach (Schedule s in t.GetSchedules())
        {
            s.PlayNextRound();
            int count = s.GetOpponentsList().Count / 2;
            List<Match> list = s.GenerateMatches(count);
            ScheduleWindow scheduleWindow = new ScheduleWindow();
            foreach (Match m in list)
            {
                scheduleWindow.ComboBoxMatches.Items.Add($"Match {m.getId()}{m.getOpponents1().Player1.getLastname()} vs {m.getOpponents2().Player1.getLastname()} à {m.getDate()}/n");
            }
            scheduleWindow.Show();

            /*
           foreach (Opponents op in s.GetOpponentsList())
           {
               if (op.Player2 != null)
               {
                   scheduleDetails += $"{x}-{op.Player2.getFirstname()}-{op.Player1.getFirstname()} id : {op.Id}\n";
               }
               else
               {
                   scheduleDetails += $"{x}-{op.Player1.getFirstname()} id : {op.Id}\n";
               }
               x++;
           }

           int count = s.GetOpponentsList().Count / 2;
           List<Match> list = s.GenerateMatches(count);
           Tournament.date = list.Last().getDate().AddDays(1);
           ScheduleWindow scheduleWindow = new ScheduleWindow();

           scheduleWindow.Title = $"Détails du planning {i}";
           foreach (Match m in list)
           {
               scheduleWindow.ComboBoxMatches.Items.Add($"Match {m.getId()}{m.getOpponents1().Player1.getLastname()} vs {m.getOpponents2().Player1.getLastname()} à {m.getDate()}/n");
           }

           foreach(Match m in list)
           {
               string matchDetails = $"Match {m.getId()}: {m.getOpponents1().Player1.getLastname()} vs {m.getOpponents2().Player1.getLastname()} à {m.getDate()}";
               scheduleWindow.AddMatchesToTreeView(matchDetails);
           }
           scheduleWindow.Show();
            */




    }
        }


