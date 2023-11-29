using Projet_Grand_Slam_Cuozzo_Ruitenbeek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    internal class Set
    {
        private int id;
        private int scoreOp1;
        private int scoreOp2;
        private int setNumber;
        private bool isTieBreak;
        private bool isFinished;
        public int id_match;
        private List<Games> games;

        public void Play()
        {

        }
        public int getId()
        {
            return id;
        }
        public int getScoreOp1()
        {
            return scoreOp1;
        }
        public int getScoreOp2()
        {
            return scoreOp2;
        }
        public int getSetNumber()
        {
            return setNumber;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public void setScoreOp1(int scoreOp1)
        {
            this.scoreOp1 = scoreOp1;
        }
        public void setScoreOp2(int scoreOp2)
        {
            this.scoreOp2 = scoreOp2;
        }
        public void setSetNumber(int setNumber)
        {
            this.setNumber = setNumber;
        }
        public int getId_match()
        {
            return id_match;
        }
        public void setId_match(int id_match)
        {
            this.id_match = id_match;
        }
    }
}
