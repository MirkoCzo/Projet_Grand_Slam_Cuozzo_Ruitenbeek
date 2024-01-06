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
            tour.Text = "Tour n° " + currentTourNumber.ToString();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Queue<Opponents> winner = new Queue<Opponents>();
            List<Schedule> scheduleList = this.t.GetSchedules();

            foreach (Schedule s in scheduleList)
            {
                int NumberTourToPlay = s.GetNbRound1(s.GetType());
                if (currentTourNumber <= NumberTourToPlay)
                {
                    await s.PlayNextRound();
                    
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

        private void AffSchedules(object sender, RoutedEventArgs e)
        {
            AfficherAvancement();
        }
        private void AfficherAvancement()
        {
            List<Schedule> scheduleList = this.t.GetSchedules();

            foreach (Schedule s in scheduleList)
            {
                int numOfMatchPlayed = s.GetMatchPlayed();
                ScheduleWindow scheduleWindow = new ScheduleWindow();

                for (int i = 0; i < numOfMatchPlayed; i++)
                {
                    TextBlock matchTextBlock = new TextBlock
                    {
                        Text = $"Match {i + 1}",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontWeight = FontWeights.Bold,
                        FontSize = 12
                    };

                    // Ajoutez le TextBlock à la grille
                    scheduleWindow.ScheduleGrid.Children.Add(matchTextBlock);

                    // Définissez la position du TextBlock dans la grille
                    Grid.SetRow(matchTextBlock, i);
                    Grid.SetColumn(matchTextBlock, 0); // Vous pouvez ajuster la colonne en fonction de vos besoins
                }

                scheduleWindow.Show();
            }
        }


    }
        }


