using Projet_Grand_Slam_Cuozzo_Ruitenbeek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    internal class Schedule
    {
        public enum ScheduleType //Je sais pas si faut créer l'enum directement dans la classe
        {
            GentlemenSingle,
            LadiesSingle,
            GentlemenDouble,
            LadiesDouble,
            MixedDouble
        }
        private ScheduleType scheduleType;
        private int actualRound;
        private Queue<Match> matcheList;
        private List<Opponents> opponentsList;

        public Schedule(ScheduleType scheduleType)
        {
            this.scheduleType = scheduleType;
            this.actualRound = 0;
            this.matcheList = new Queue<Match>();
        }
        public int NbWinningSets()
        {
            switch (scheduleType)
            {
                case ScheduleType.GentlemenSingle:
                    return 3; // 3 sets gagnants pour les programmes simples
                case ScheduleType.LadiesSingle:
                    return 2; // 2 sets gagnants pour les programmes simples
                case ScheduleType.GentlemenDouble:
                    return 2; // 2 sets gagnants pour les programmes doubles
                case ScheduleType.LadiesDouble:
                    return 2; // 2 sets gagnants pour les programmes doubles
                case ScheduleType.MixedDouble:
                    return 2; // 2 sets gagnants pour les programmes doubles
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void PlayNextRound()
        {

        }
        public Player GetWinner()
        {
            return this.GetWinner();
        }
        public ScheduleType GetType()
        {
            return scheduleType;
        }
        public int GetActualRound()
        {
            return actualRound;
        }
        public void Initialize()
        {
            if (scheduleType == ScheduleType.GentlemenSingle|| scheduleType == ScheduleType.LadiesSingle)
            {
                for (int i = 0; i < 64; i++)
                {
                    this.matcheList.Enqueue(new Match());
                }
            }
            else if (scheduleType == ScheduleType.GentlemenDouble || scheduleType == ScheduleType.LadiesDouble || scheduleType == ScheduleType.MixedDouble)
            {
                for (int i = 0; i < 32; i++)
                {
                    this.matcheList.Enqueue(new Match());
                }
            }            
        }
    }
}
