using System.Collections.Generic;
using Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Awards.DAL
{
    public class AwardsMemoryStorage : IAwardsStorable
    {
        private static List<Award> Awards { get; set; }
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        static AwardsMemoryStorage()//Статический коструктор синхронизирующийся с базой данных
        {
            Awards = new List<Award>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Awards", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Award user = new Award()
                        {
                            Title = $"{reader.GetValue(0)}",
                        };
                        Awards.Add(user);
                    }
                }
                reader.Close();
            }
        }
        public bool СreateAward(Award award)//Создаем награду
        {
            if (Awards.Any(item => item.Title == award.Title))
                return false;
            Awards.Add(award);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Awards (Title) VALUES ('{award.Title}')", connection);
                command.ExecuteNonQuery();
            }
            return true;
        }
        public bool RemoveAward(Award award)//Удаляем награду
        {
            if (Awards.All(item => item.Title != award.Title))
                return false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE  FROM Awards WHERE Title='{award.Title}'", connection);
                command.ExecuteNonQuery();
            }
            foreach (Award item in Awards)
            {
                if(item.Title == award.Title)
                {
                    Awards.Remove(item);
                    break;
                }
            }
            return true;
        }
        public ICollection<Award> GetAllAwards()
        {
            return Awards;
        }
    }
}
