using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    internal class MatchInfo
    {
        public DateTime Date { get; set; }
        public string Round { get; set; }
        public string LooserName { get; set; }
        
        public string WinnerName { get; set; }
        
        public int ScoreWinner { get; set; }
        public int ScoreLooser { get; set; }
        public int Duration { get; set; }
        public string CourtName { get; set; }
        public string RefereeName { get; set; }
        public string TournamentName { get; set; }
        public string Type { get; set; }
        public string IsTieBreak { get; set; }
        public string IsSuperTieBreak { get; set; }
        public List<int> ScoresSetsWinner { get; set; }
        public List<int> ScoresSetsLooser { get; set; }
        public MatchInfo(DateTime date, string round, string loosername, string winnerName, int scorewinner, int scorelooser, string isTieBreak, string isSuperTieBreak, List<int> scoresSetsWinner, List<int> scoresSetsLooser)
        {
            Date = date;
            Round = round;
            LooserName = loosername;
            WinnerName = winnerName;
            ScoreWinner = scorewinner;
            ScoreLooser = scorelooser;
            IsTieBreak = isTieBreak;
            IsSuperTieBreak = isSuperTieBreak;
            ScoresSetsWinner = scoresSetsWinner;
            ScoresSetsLooser = scoresSetsLooser;
        }
    }
}
