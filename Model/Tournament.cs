using Projet_Grand_Slam_Cuozzo_Ruitenbeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
