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
        private int currentTourNumber = 1;
        Tournament t = new Tournament("TestTournoi", new DateTime(2024, 1, 1));
        public MainWindow()
        {
            InitializeComponent();
            this.t.GenerateSchedules();
            UpdateTourTextBlock();
            

        }
        private void UpdateTourTextBlock()
        {
            // Mettez à jour le contenu du TextBlock avec le numéro actuel du tour
            tour.Text = "Tour n° " + currentTourNumber.ToString();
        }

        // MainWindow.xaml.cs
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Queue<Opponents> winner = new Queue<Opponents>();
            List<Schedule> scheduleList = this.t.GetSchedules();

            foreach (Schedule s in scheduleList)
            {
                int NumberTourToPlay = s.GetNbRound1(s.GetType());
                if (currentTourNumber <= NumberTourToPlay && s.GetType() == Schedule.ScheduleType.GentlemenSingle)
                {
                    await s.PlayNextRound();
                    match.Text = "Match n° " + s.GetCurrentMatch().getId();
                }

                winner = s.GetOpponentsList();

                if (winner.Count == 1)
                {
                    Opponents op = winner.Dequeue();
                    if (op.Player2 != null)
                    {
                        MessageBox.Show($"Le gagnant est {op.Player1.getLastname()} et {op.Player2.getLastname()}");
                    }
                    else
                    {
                        MessageBox.Show($"Le gagnant est {op.Player1.getLastname()}");
                    }
                    winner.Enqueue(op);
                }
            }

            this.currentTourNumber++;
            UpdateTourTextBlock();
            stopwatch.Stop();

            // Afficher le temps écoulé
            MessageBox.Show($"Temps écoulé : {stopwatch.Elapsed}");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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


