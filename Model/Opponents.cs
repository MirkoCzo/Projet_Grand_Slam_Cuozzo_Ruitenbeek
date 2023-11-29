using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek.Model
{
    internal class Opponents
    {
        int id;
        Player player1;
        Player? player2;

        public Opponents(int id, Player player1, Player? player2)
        {
            this.id = id;
            this.player1 = player1;
            this.player2 = player2;
        }
        public int Id { get { return id; }}

    }
}
