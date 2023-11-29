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
    internal class PlayerDAO : DAO<Player>
    {
        public override bool Create(Player obj)
        {
            bool succes = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Player(FirstName, LastName, Rank, Gender, Nationality) VALUES(@FirstName, @LastName, @Rank, @Gender, @Nationality)", connection);
                    cmd.Parameters.AddWithValue("FirstName", obj.getFirstname());
                    cmd.Parameters.AddWithValue("LastName", obj.getLastname());
                    cmd.Parameters.AddWithValue("Rank", obj.getRank());
                    cmd.Parameters.AddWithValue("Gender", obj.getGender());
                    cmd.Parameters.AddWithValue("Nationality", obj.getNationality());
                    connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    succes = res > 0;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return succes;
        }


        public override bool Delete(Player obj)
        {
            bool succes = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Player WHERE FirstName = @FirstName AND LastName = @LastName", connection);
                    cmd.Parameters.AddWithValue("FirstName", obj.getFirstname());
                    cmd.Parameters.AddWithValue("LastName", obj.getLastname());
                    connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    succes = res > 0;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return succes;
        }

        public override Player Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Player> FindAll()
        {
            List<Player> players = new List<Player>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Player", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Player player = new Player();
                        player.setFirstname(reader.GetString(1));
                        player.setLastname(reader.GetString(2));
                        player.setRank(reader.GetInt32(3));
                        player.setGender(reader.GetString(4));
                        player.setNationality(reader.GetString(5));
                        players.Add(player);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return players;
        }

        public override bool Update(Player obj)
        {
            throw new NotImplementedException();
        }
    }
}

