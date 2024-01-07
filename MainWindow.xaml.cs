using Projet_Grand_Slam_Cuozzo_Ruitenbeek.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        private int currentTourNumber = 0;
        Tournament t = new Tournament("TestTournoi", new DateTime(2024, 1, 1));

        public List<int> ScoresSetsWinner { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            this.t.GenerateSchedules();
            UpdateTourTextBlock();
        }

        private void UpdateTourTextBlock()
        {
            tourSingle.Text = GetRoundSingle(currentTourNumber);
            tourDouble.Text = GetRoundDouble(currentTourNumber);
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
                    Opponents win = s.GetOpponentsList().Peek();
                    if (s.GetType() == Schedule.ScheduleType.GentlemenSingle)
                    {
                        gs.Text = $"Winner : {win.Player1.getFirstname()} {win.Player1.getLastname()}";
                    }
                    else if (s.GetType() == Schedule.ScheduleType.LadiesSingle)
                    {
                        ls.Text = $"Winner : {win.Player1.getFirstname()} {win.Player1.getLastname()}";
                    }
                    else if (s.GetType() == Schedule.ScheduleType.GentlemenDouble)
                    {
                        gd.Text = $"Winner : {win.Player1.getFirstname()} {win.Player1.getLastname()} - {win.Player2.getFirstname()} {win.Player2.getLastname()}";
                    }
                    else if (s.GetType() == Schedule.ScheduleType.LadiesDouble)
                    {
                        ld.Text = $"Winner : {win.Player1.getFirstname()} {win.Player1.getLastname()} - {win.Player2.getFirstname()} {win.Player2.getLastname()}";
                    }
                    else
                    {
                        md.Text = $"Winner : {win.Player1.getFirstname()} {win.Player1.getLastname()} - {win.Player2.getFirstname()} {win.Player2.getLastname()}";
                    }
                }
            }

            this.currentTourNumber++;
            if(currentTourNumber == 7)
            {
                boutonstart.IsEnabled = false;
            }
            UpdateTourTextBlock();
            stopwatch.Stop();

            // Afficher le temps écoulé
            MessageBox.Show($"Temps écoulé : {stopwatch.Elapsed}");
        }

        private void AffSchedules(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (int.TryParse(button.Tag.ToString(), out int param))
                {
                    AfficherAvancement(param);
                }
            }
        }

        private void AfficherAvancement(int enumValue)
        {
            int CurrentMatch = 0;
            List<Schedule> scheduleList = this.t.GetSchedules();
            Schedule type = scheduleList[enumValue];
            ScheduleWindow scheduleWindow = new ScheduleWindow();
            List<int> ScoresOpp1 = new List<int>();
            List<int> ScoresOpp2 = new List<int>();
           
            for (int i = 0; i < type.GetNbRound1(type.GetType()); i++)
            {
                List<MatchInfo> matchInfos = new List<MatchInfo>();
                List<int> ScoreWinner = new List<int>();
                List<int> ScoreLooser = new List<int>();
                string TypeString = Schedule.GetScheduleString(type.GetType());
                foreach (Match m in type.GetMatches())
                {
                    DateTime date = m.getDate();
                    int round = m.getRound();
                    string win;
                    string loose;
                    int scoreWin = m.getScoreWinner();
                    int scoreLoose = m.getScoreLooser();
                    string TieBreak = "Non";
                    string SuperTieBreak = "Non";
                    List<Set> sets = m.getSets();
                    foreach (Set set in sets)
                    {
                        ScoresOpp1.Add(set.getScoreOp1());
                        ScoresOpp2.Add(set.getScoreOp2());
                        bool isTieBreak = set.getIsTieBreak();
                        bool isSuperTieBreak = set.getIsSuperTieBreak();
                        if (isTieBreak)
                        {
                            TieBreak = "Oui";
                        }

                        if (isSuperTieBreak)
                        {
                            SuperTieBreak = "Oui";
                        }
                    }
                    if (ScoresOpp1.Last() > ScoresOpp2.Last())
                    {
                        ScoreWinner = ScoresOpp1;
                        ScoreLooser = ScoresOpp2;
                        ScoresOpp1.Clear();
                        ScoresOpp2.Clear();
                    }
                    else
                    {
                        ScoreLooser = ScoresOpp1;
                        ScoreWinner = ScoresOpp2;
                        ScoresOpp1.Clear();
                        ScoresOpp2.Clear();
                    }
                    
                    if (type.GetType() == Schedule.ScheduleType.GentlemenSingle || type.GetType() == Schedule.ScheduleType.LadiesSingle)
                    {
                        Player p1 = m.getOpponents1().Player1;
                        Player p2 = m.getOpponents2().Player1;
                        Opponents winner = m.getWinner();
                        Player w = winner.Player1;
                        if (w.getLastname().Equals(p1.getLastname()))
                        {
                            win = $" {p1.getLastname()} {p1.getFirstname()}";
                            loose = $" {p2.getLastname()} {p2.getFirstname()}";
                        }
                        else
                        {
                            loose = $" {p1.getLastname()} {p1.getFirstname()}";
                            win = $" {p2.getLastname()} {p2.getFirstname()}";
                        }
                        MatchInfo matchInfo = new MatchInfo(date, GetRoundSingle(round), loose, win, scoreWin, scoreLoose, TieBreak, SuperTieBreak,ScoreWinner,ScoreLooser);
                        matchInfos.Add(matchInfo);
                    }
                    else
                    {
                        Player p1 = m.getOpponents1().Player1;
                        Player p2 = m.getOpponents1().Player2;
                        Player p3 = m.getOpponents2().Player1;
                        Player p4 = m.getOpponents2().Player2;
                        string p1Name = $" {p1.getLastname()} {p1.getFirstname()}";
                        string p2Name = $" {p2.getLastname()} {p2.getFirstname()}";
                        string p3Name = $" {p3.getLastname()} {p3.getFirstname()}";
                        string p4Name = $" {p4.getLastname()} {p4.getFirstname()}";
                        Opponents winner = m.getWinner();
                        Player w1 = winner.Player1;
                        Player w2 = winner.Player2;
                        if (w1.getLastname().Equals(p1.getLastname()))
                        {
                            win = $" {p1.getLastname()} {p1.getFirstname()} - {p2.getLastname()} {p2.getFirstname()}";
                            loose = $"{p3.getLastname()} {p3.getFirstname()} - {p4.getLastname()} {p4.getFirstname()} ";
                        }
                        else
                        {
                            loose = $" {p1.getLastname()} {p1.getFirstname()} - {p2.getLastname()} {p2.getFirstname()}";
                            win = $"{p3.getLastname()} {p3.getFirstname()} - {p4.getLastname()} {p4.getFirstname()} ";
                        }
                        MatchInfo matchInfo = new MatchInfo(date, GetRoundDouble(round), loose, win, scoreWin, scoreLoose, TieBreak, SuperTieBreak, ScoreWinner, ScoreLooser) ;
                        matchInfos.Add(matchInfo);
                    }
                }
                scheduleWindow.MatchItemControl.ItemsSource = matchInfos;
               
                scheduleWindow.TitleText = TypeString;
                CurrentMatch++;
            }

            scheduleWindow.Show();
        }

        public string GetRoundSingle(int round)
        {
            switch (round)
            {
                case 0:
                    return "1er tour";
                case 1:
                    return "2ème tour";
                case 2:
                    return "3ème tour";
                case 3:
                    return "4ème tour";
                case 4:
                    return "Quart de finale";
                case 5:
                    return "Demi-finale";
                case 6:
                    return "Finale";
                default:
                    return "Terminé";
            }
        }

        public string GetRoundDouble(int round)
        {
            switch (round)
            {
                case 0:
                    return "1er tour";
                case 1:
                    return "2ème tour";
                case 2:
                    return "3ème tour";
                case 3:
                    return "Quart de finale";
                case 4:
                    return "Demi-finale";
                case 5:
                    return "Finale";
                default:
                    return "Terminé";
            }
        }
    }
}
