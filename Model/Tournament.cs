using Projet_Grand_Slam_Cuozzo_Ruitenbeek;
using Projet_Grand_Slam_Cuozzo_Ruitenbeek.DAO;
using Projet_Grand_Slam_Cuozzo_Ruitenbeek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Projet_Grand_Slam_Cuozzo_Ruitenbeek.Schedule;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    internal class Tournament
    {
        private int id;
        private string name;
        //private List<Court> courtsList;
        //private List<Referee> refereesList;
        private List<Schedule> scheduleList;

        public Tournament(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public Tournament()
        {
          
        }
        
        public void Play()
        {
            GenerateSchedules();
            foreach (Schedule s in scheduleList)
            {
                s.PlayNextRound();
            }
        }
        public void GenerateSchedules()//1
        {
            this.scheduleList = new List<Schedule>();
            foreach (ScheduleType type in Enum.GetValues(typeof(ScheduleType)))
            {
                this.scheduleList.Add(new Schedule(type));
            }
            FillSchedule();
        }       
        public void FillSchedule()//2
        {
            List<Player> MenList = FetchPlayers("MALE");
            List<Player> WomenList = FetchPlayers("FEMALE");
            foreach (Schedule s in scheduleList)
            {
                s.Fill(MenList,WomenList);
            }
        }        
        
        
        public List<Player> FetchPlayers(string gender)
        {
            PlayerDAO playerDAO = new PlayerDAO();
            List<Player> playersList = new List<Player>();
            playersList = playerDAO.FindByGender(gender);
            return playersList;
        }
        
        public int getId() { return id; }

        public string getName() { return name; }

        public void setId(int id) { this.id = id; }

        public void setName(string name) { this.name = name; }

        public List<Schedule> GetSchedules() { return scheduleList; }
    }
}
