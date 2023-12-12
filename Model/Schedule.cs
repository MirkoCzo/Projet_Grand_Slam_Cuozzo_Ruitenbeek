using Projet_Grand_Slam_Cuozzo_Ruitenbeek.DAO;
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
            Initialize();
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
        public void Fill(List<Player> men, List<Player> women)
        {
            if (this.scheduleType == ScheduleType.GentlemenSingle || this.scheduleType == ScheduleType.LadiesSingle)
            {
                if (this.scheduleType == ScheduleType.GentlemenSingle)
                {
                   GenerateOpponentsSingle(men);
                }
                else
                {
                   GenerateOpponentsSingle(women);
                }
            }
            else
            {
                GenerateOpponentsDouble(this.scheduleType, men, women);
            }
        }
        private void GenerateOpponentsDouble(ScheduleType type, List<Player> men, List<Player> women)
        {
            List<Opponents> opponentsList = new List<Opponents>();
            if(type == ScheduleType.GentlemenDouble)
            {
                for (int i = 0; i < 64; i++)
                {
                    opponentsList.Add(new Opponents(i, men[i *2], men[(i*2)+1]));
                }
                this.opponentsList = opponentsList;
                Shuffle(opponentsList);
            }
            else if(type == ScheduleType.LadiesDouble)
            {
                for (int i = 0; i < 64; i++)
                {
                    opponentsList.Add(new Opponents(i, women[i * 2], women[(i * 2) + 1]));
                }
                this.opponentsList = opponentsList;
                Shuffle(opponentsList);


            }
            else if(type == ScheduleType.MixedDouble)
            {
                List<Player> MixedList= Schedule.MixList(men, women, 64);
                for (int i = 0; i < 64; i++)
                {
                    opponentsList.Add(new Opponents(i, MixedList[i * 2], MixedList[(i * 2) + 1]));
                }
                this.opponentsList = opponentsList;
                Shuffle(opponentsList);

            }

        }
        public void GenerateOpponentsSingle(List<Player> list)
        {
            List<Opponents> opponentsList = new List<Opponents>();
            for (int i = 0; i < 128; i++)
            {
                opponentsList.Add(new Opponents(i, list[i], null));
            }
            this.opponentsList = opponentsList;
            Shuffle(opponentsList);

        }
        public void CreateMatchs()
        {
            for(int i = 0; i < opponentsList.Count; i+=2)
            {
                Match  m = new Match();
                m.setOpponents1(this.opponentsList[i]);
                m.setOpponents2(this.opponentsList[i+1]);
                this.matcheList.Enqueue(m);
            }
        }

        static List<T> MixList<T>(List<T> liste1, List<T> liste2, int taille)
        {
            List<T> res = new List<T>();
            taille = Math.Min(Math.Min(liste1.Count, liste2.Count), taille);
            for (int i = 0; i < taille; i++)
            {
                res.Add(liste1[i]);
                res.Add(liste2[i]);
            }
            return res;
        }
        static void Shuffle<T>(List<T> list)
        {
            Random rand = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T valeur = list[k];
                list[k] = list[n];
                list[n] = valeur;
            }
        }
    }
}
