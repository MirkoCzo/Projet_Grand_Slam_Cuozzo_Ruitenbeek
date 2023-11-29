using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek.DAO
{
    internal class MatchDAO : DAO<Match>
    {
        public MatchDAO()
        {
        }

        public override bool Create(Match obj)
        {
            bool success = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Match(Date,Duration,Round,Type,Id_Opponent_1,Id_Opponent_2,Id_Tournament,Id_Court,Id_Ref) VALUES(@Date,@Duration,@Roud,@Type,@Id_Opponent_1,@Id_Opponent_2,@Id_Tournament,@Id_Court,@Id_Ref)", connection);
                    cmd.Parameters.AddWithValue("Date", obj.getDate());
                    cmd.Parameters.AddWithValue("Duration", obj.getDuration());
                    cmd.Parameters.AddWithValue("Round", obj.getRound());
                    cmd.Parameters.AddWithValue("Type", obj.getType());
                    cmd.Parameters.AddWithValue("Id_Opponent_1", obj.getOpponents1().Id);
                    cmd.Parameters.AddWithValue("Id_Opponent_2", obj.getOpponents2().Id);
                    cmd.Parameters.AddWithValue("Id_Tournament", obj.getId_Tournament());
                    cmd.Parameters.AddWithValue("Id_Court", obj.getCourt().Id);


                    connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    success = res > 0;
                }

            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override bool Delete(Match obj)
        {
            throw new NotImplementedException();
        }

        public override Match Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Match> FindAll()
        {
            throw new NotImplementedException();
        }

        public override bool Update(Match obj)
        {
            throw new NotImplementedException();
        }
    }
}
