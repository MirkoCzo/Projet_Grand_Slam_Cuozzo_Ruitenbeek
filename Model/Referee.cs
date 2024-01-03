using Projet_Grand_Slam_Cuozzo_Ruitenbeek;
using Projet_Grand_Slam_Cuozzo_Ruitenbeek.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    internal class Referee : Person
    {

        private bool isAvailable;
        //private static Queue<Referee> referees = new Queue<Referee>();

        
        public bool Available()
        {
            return isAvailable;
        }
        public void Occupy()
        {
           isAvailable = false;
        }

        public void Release()
        {
            if (isAvailable)
            {
                Console.WriteLine("L'arbitre est déjà disponible.");
            }
            else isAvailable = true;
        }
        public void FillList()
        {
            RefereeDAO refereeDAO = new RefereeDAO();
            Queue<Referee> tmp =  new Queue<Referee>(refereeDAO.FindAll());
            Referee.referees = tmp;
        }
         
    }
}
