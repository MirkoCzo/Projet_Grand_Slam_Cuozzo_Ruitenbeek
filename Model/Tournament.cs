using Projet_Grand_Slam_Cuozzo_Ruitenbeek;
using Projet_Grand_Slam_Cuozzo_Ruitenbeek.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projet_Grand_Slam_Cuozzo_Ruitenbeek.Schedule;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    internal class Tournament
    {
        private int id;
        private string name;
        private List<Court> courtsList;
        private List<Match> matchesList;
        private List<Player> playersList;
        private List<Referee> refereesList;
        private List<Schedule> scheduleList;


        public int getId() { return id; }

        public string getName() { return name; }

        public void setId(int id) { this.id = id;}

        public void setName(string name) { this.name = name;}


        public void Play()
        {

        }
        public void GenerateSchedules()
        {
            this.scheduleList = new List<Schedule>();
            foreach (ScheduleType type in Enum.GetValues(typeof(ScheduleType)))
            {
                this.scheduleList.Add(new Schedule(type));
            }
        }
        public List<Player> FetchPlayers(string gender)
        {
            PlayerDAO playerDAO = new PlayerDAO();
            playersList = playerDAO.FindByGender(gender);
            return playersList;
        }
        public List<Referee> FetchReferees()
        {
            RefereeDAO refereeDAO = new RefereeDAO();
            refereesList = refereeDAO.FindAll();
            return refereesList;
        }
        public List<Court> FetchCourts()
        {
            CourtDAO courtDAO = new CourtDAO();
            courtsList = courtDAO.FindAll();
            return courtsList;
        }
        public void GeneratesMatchs()
        {
            foreach(Schedule s in scheduleList)
            {
                s.Initialize();
            }  
        }
        
    }
}
