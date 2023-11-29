using Projet_Grand_Slam_Cuozzo_Ruitenbeek.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek.DAO
{
    internal class RefereeDAO : DAO<Referee>
    {
        public override bool Create(Referee obj)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Referee(FirstName,LastName,Nationality) VALUES(@FirstName,@LastName,@Nationality)", connection);
                    cmd.Parameters.AddWithValue("FirstName", obj.getFirstname());
                    cmd.Parameters.AddWithValue("LastName", obj.getLastname());
                    cmd.Parameters.AddWithValue("Nationality",obj.getNationality());
                    connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    success = res > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }

        public override bool Delete(Referee obj)
        {
            bool success = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Referee WHERE FirstName = @FirstName AND LastName = @LastName", connection);
                    cmd.Parameters.AddWithValue("FirstName",obj.getFirstname());
                    cmd.Parameters.AddWithValue("LastName", obj.getLastname);
                    connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    success = res > 0;
                }
            }catch (SqlException ex ) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override Referee Find(int id)
        {
            throw new NotImplementedException();
        }
        public override bool Update(Referee obj)
        {
            throw new NotImplementedException();
        }
        public override List<Referee> FindAll()
        {
            List<Referee> referees = new List<Referee>();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Referee", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) 
                    {
                        Referee referee = new Referee();
                        referee.setFirstname(reader.GetString(1));
                        referee.setLastname(reader.GetString(2));
                        referee.setNationality(reader.GetString(3));
                        referees.Add(referee);

                    }
                }
            }catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return players;
        }
    }
}
