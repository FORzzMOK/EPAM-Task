using Entities;
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing;

namespace Users.DAL
{
    public class UsersMemoryStorage : IUsersStorable
    {
        private static List<User> Users { get; set; }
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        static UsersMemoryStorage()//Статический коструктор синхронизирующийся с базой данных
        {
            Users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User()
                        {
                            Id = int.Parse($"{reader.GetValue(0)}"),
                            Name = $"{reader.GetValue(1)}",
                            Surname = $"{reader.GetValue(2)}",
                            DateOfBirth = DateTime.Parse($"{reader.GetValue(3)}"),
                            Avatar = (byte[])reader.GetValue(4)
                        };
                        Users.Add(user);
                    }
                }
                reader.Close();
            }
            foreach (User user in Users)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT Awards_title FROM UsersAndAwardsRelations WHERE Users_ID= {user.Id}", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.Awards.Add($"{reader.GetValue(0)}");
                        }
                    }
                    reader.Close();
                }
            }
        }
        public bool AddUser(User user)//Добавляем пользователя
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Image image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"MyPhoto\stub.png");
                MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] image_byte = memoryStream.ToArray();
                user.Avatar = image_byte;
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Users (Name, Surname, DateOfBirth, Avatar) VALUES ('{user.Name}', '{user.Surname}', '{user.DateOfBirth.ToString("yyyy-MM-dd")}', @Avatar);SET @ID=SCOPE_IDENTITY()", connection);
                command.Parameters.Add("@Avatar", SqlDbType.VarBinary, 8000).Value = image_byte;
                SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int, 4)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
                user.Id = int.Parse($"{idParam.Value}");
            }
            Users.Add(user);
            return true;
        }
        public bool RemoveUser(int users_ID)//Удаляем пользователя
        {
            if (Users.All(item => item.Id != users_ID))
                return false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM Users WHERE ID='{users_ID}'", connection);
                command.ExecuteNonQuery();
            }
            foreach (User item in Users)
            {
                if (item.Id == users_ID)
                {
                    Users.Remove(item);
                    break;
                }
            }
            return true;
        }
        public bool EditUser(int users_ID, User user)
        {
            if (Users.All(item => item.Id != users_ID))
                return false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Users SET Name='{user.Name}', Surname='{user.Surname}', DateOfBirth='{user.DateOfBirth.ToString("yyyy-MM-dd")}' WHERE ID={users_ID}", connection);
                command.ExecuteNonQuery();
            }
            foreach (User item in Users)
            {
                if (item.Id == users_ID)
                {
                    item.Name = user.Name;
                    item.Surname = user.Surname;
                    item.DateOfBirth = user.DateOfBirth;
                    break;
                }
            }
            return true;
        }//Редактируем пользователя
        public bool AddAward(int users_ID, Award award)
        {
            if (Users.All(item => item.Id != users_ID))
                return false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO UsersAndAwardsRelations (Users_ID, Awards_title) VALUES ('{users_ID}', '{award.ToString()}')", connection);
                command.ExecuteNonQuery();
            }
            foreach(User user in Users)
            {
                if (user.Id == users_ID)
                {
                    user.Awards.Add(award.Title);
                    break;
                }     
            }
            return true;
        }
        public bool RemoveAward(int users_ID, Award award)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM UsersAndAwardsRelations WHERE Users_ID='{users_ID}' AND Awards_title='{award.ToString()}'", connection);
                int count = command.ExecuteNonQuery();
                if (count == 0)
                    return false;
            }
            foreach (User user in Users)
            {
                if (user.Id == users_ID)
                {
                    List<string> newString = new List<string>();
                    foreach(string item in user.Awards)
                    {
                        if(item != award.Title)
                            newString.Add(item);
                    }
                    user.Awards = newString;
                    break;
                }

            }
            return true;
        }
        public bool AddImage(int user_ID, byte[] imageByte)
        {
            if (Users.All(item => item.Id != user_ID))
                return false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE Users SET Avatar=@Avatar WHERE ID={user_ID}", connection);
                command.Parameters.Add("@Avatar", SqlDbType.VarBinary, 8000).Value = imageByte;
                command.ExecuteNonQuery();
            }
            foreach (User user in Users)
            {
                if (user.Id == user_ID)
                {
                    user.Avatar = imageByte;
                    break;
                }
            }
            return true;
        }
        public ICollection<User> GetAllUsers()
        {
            return Users;
        }
    }
}
