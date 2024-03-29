﻿using Projet_Grand_Slam_Cuozzo_Ruitenbeek.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek.DAO
{
    internal class GamesDAO : DAO<Games>
    {
        public override int Create(Games obj)
        {
            int res = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Games (Game_Number,Score_Op_One,Score_Op_Two,Id_Set) OUTPUT INSERTED.Id_Game VALUES (@GameNumber, @ScoreOne, @ScoreTwo, @Id_Set)", connection);
                    cmd.Parameters.AddWithValue("GameNumber", obj.getGameNumber());
                    cmd.Parameters.AddWithValue("ScoreOne",obj.getScoreOp1());
                    cmd.Parameters.AddWithValue("ScoreTwo", obj.getScoreOp2());
                    cmd.Parameters.AddWithValue("Id_Set", obj.getIdSet());

                    connection.Open();
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return res;
        }

        public override bool Delete(Games obj)
        {
            bool succes = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Games WHERE Id_Game = @Id", connection);
                    cmd.Parameters.AddWithValue("Id", obj.getId());
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

        public override Games Find(int id)
        {
            Games game = new Games();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Games WHERE Id_Game = @Id", connection);
                    cmd.Parameters.AddWithValue("Id", id);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        game.setId(reader.GetInt32(0));
                        game.setGameNumber(reader.GetInt32(1));

                        List<int> scoresOpOne = new List<int> { reader.GetInt32(2) };
                        List<int> scoresOpTwo = new List<int> { reader.GetInt32(3) };

                        game.setScoreOpOne(scoresOpOne);
                        game.setScoreOpTwo(scoresOpTwo);

                        game.setIdSet(reader.GetInt32(4));
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return game;
        }

        public override List<Games> FindAll()
        {
            List<Games> games = new List<Games>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.Games", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Games game = new Games();
                        game.setId(reader.GetInt32(0));
                        game.setGameNumber(reader.GetInt32(1));

                        List<int> scoresOpOne = new List<int> { reader.GetInt32(2) };
                        List<int> scoresOpTwo = new List<int> { reader.GetInt32(3) };

                        game.setScoreOpOne(scoresOpOne);
                        game.setScoreOpTwo(scoresOpTwo);

                        game.setIdSet(reader.GetInt32(4));
                        games.Add(game);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return games;
        }

        public override bool Update(Games obj)
        {
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"UPDATE dbo.Games SET Game_Number = @Game, Score_Op_One = @ScoreOne, Score_Op_Two = @ScoreTwo, Id_Set=@Id_Set WHERE Id_Game = @Id", connection);
                    cmd.Parameters.AddWithValue("Id", obj.getId());
                    cmd.Parameters.AddWithValue("Game",obj.getGameNumber());
                    cmd.Parameters.AddWithValue("ScoreOne", obj.getScoreOpOne());
                    cmd.Parameters.AddWithValue("ScoreTwo", obj.getScoreOpTwo());
                    cmd.Parameters.AddWithValue("Id_Set", obj.getIdSet());

                    connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    success = res > 0;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return success;
        }
    }
}
