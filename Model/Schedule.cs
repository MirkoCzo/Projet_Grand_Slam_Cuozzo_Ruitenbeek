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

        public void NbWinningSets()
        {

        }
        public void PlayNextRound()
        {

        }
        public Player GetWinner()
        {
            return this.GetWinner();
        }
    }
}
