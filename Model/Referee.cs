using Projet_Grand_Slam_Cuozzo_Ruitenbeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    internal class Referee : Person
    {

        private bool isAvailable;

        public bool Available()
        {
            return isAvailable;
        }

        public void Release()
        {
            if (isAvailable)
            {
                Console.WriteLine("L'arbitre est déjà disponible.");
            }
            else isAvailable = true;
        }
    }
}
