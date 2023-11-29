using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek.Model
{
    internal class Games
    {
        private int id;
        private int game_Number;
        private int score_Op_One;
        private int score_Op_Two;

        public int getId() { return id; }
        public int getGameNumber() { return game_Number;}
        public int getScoreOpOne() { return score_Op_One;}
        public int getScoreOpTwo() {  return score_Op_Two;}
        public void setId(int id) { this.id = id;}
        public void setGameNumber(int game_Number) {  this.game_Number = game_Number;}
        public void setScoreOpOne(int score) {  this.score_Op_One = score;}
        public void setScoreOpTwo(int score) { this.score_Op_Two = score;}
    }
}
