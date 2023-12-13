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
        private Queue<Opponents> opponentsList;
        OpponentsDAO opponentsDAO = new OpponentsDAO();

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
        public void PlayNextRound() {
            for(int i = 0; i < opponentsList.Count / 2;  i++)
            {
                Opponents op1 = opponentsList.Dequeue();
                Opponents op2 = opponentsList.Dequeue();
                Match m = new Match();
                m.setOpponents1(op1);
                m.setOpponents2(op2);
                m.setDate(DateTime.Now);
                m.setReferee(null);
                m.setCourt(null);
                m.setRound(actualRound);
                matcheList.Enqueue(m);
                m.Play();
               
                

            }
            this.actualRound++;
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
        private void GenerateOpponentsDouble(ScheduleType type, List<Player> men, List<Player> women)//GENERER LA LISTE DES OPPOSANTS EN CAS DE DOUBLE 64 opposants 32 matchs
        {
            Queue<Opponents> opponentsList = new Queue<Opponents>();
            if(type == ScheduleType.GentlemenDouble)
            {
                for (int i = 0; i < 64; i++)
                {
                    Opponents oponnents = new Opponents(men[i *2], men[(i*2)+1]);
                    if (opponentsDAO.Create(oponnents))
                    {
                        opponentsList.Enqueue(oponnents);
                    }
                }
                this.opponentsList = opponentsList;
                Shuffle(opponentsList);
            }
            else if(type == ScheduleType.LadiesDouble)
            {
                for (int i = 0; i < 64; i++)
                {
                    Opponents opponents =  new Opponents(women[i * 2], women[(i * 2) + 1]);
                    if (opponentsDAO.Create(opponents))
                    {
                        opponentsList.Enqueue(opponents);
                    }
                }
                this.opponentsList = opponentsList;
                Shuffle(opponentsList);


            }
            else if(type == ScheduleType.MixedDouble)
            {
                List<Player> MixedList= Schedule.MixList(men, women, 64);
                for (int i = 0; i < 64; i++)
                {
                    Opponents oponents = new Opponents(MixedList[i * 2], MixedList[(i * 2) + 1]);
                    if (opponentsDAO.Create(oponents))
                    {
                        opponentsList.Enqueue(oponents);
                    }
                }
                this.opponentsList = opponentsList;
                Shuffle(opponentsList);

            }

        }
        public void GenerateOpponentsSingle(List<Player> list)//GENERER LA LISTE DES OPPOSANTS EN CAS DE SIMPLE 128 opposants 64 matchs
        {
            Queue<Opponents> opponentsList = new Queue<Opponents>();
            for (int i = 0; i < 128; i++)
            {
                Opponents opponents = new Opponents(list[i], null);
                if (opponentsDAO.Create(opponents))
                {
                    opponentsList.Enqueue(opponents);
                }
            }
            this.opponentsList = opponentsList;
            Shuffle(opponentsList);

        }
        
        public Queue<Match> getMatchsList()
        {
            return matcheList;
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
        static void Shuffle<T>(Queue<T> queue)
        {
            Random rand = new Random();
            T[] array = queue.ToArray();

            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = array[k];
                array[k] = array[n];
                array[n] = value;
            }

            queue.Clear();
            foreach (T item in array)
            {
                queue.Enqueue(item);
            }
        }
    }
}
