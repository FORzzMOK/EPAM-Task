using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersEntities;
using System.IO;
using System.Globalization;

namespace Users_and_awards.DAL
{
    public class UsersData
    {
        static UsersData()
        {
            DataSynchronizationStart();
        }
        private static List<User> UsersList = new List<User>();
        public static void AddUser(User newUser)
        {
            UsersList.Add(newUser);
            File.AppendAllText("MyData.txt", $"{newUser.ToString()} \n");
        }
        public static bool RemoveUser(int usersId)
        {
            User myUser = GetUserById(usersId);
            if (myUser != null)
            {
                //string line = "";
                //using (StreamReader reader = new StreamReader("MyData.txt"))
                //{
                //    using (StreamWriter writer = new StreamWriter("MyDataNew.txt"))
                //    {
                //        while ((line = reader.ReadLine()) != null)
                //        {
                //            if (line.StartsWith($"{usersId}")) continue;
                //            writer.WriteLine(line);
                //        }
                //    }
                //}
                UsersList.Remove(myUser);
                return true;
            }
            else return false;

        }
        public static int GetId()
        {
            int newId = -1;
            foreach (User item in UsersList)
            {
                if (item.Id > newId) newId = item.Id;
            }
            return newId + 1;
        }
        public static User GetUserById(int usersId)
        {
            foreach (User item in UsersList)
            {
                if (item.Id == usersId)
                {
                    return item;
                }
            }
            return null;
        }
        public static string GetUsersList()
        {
            StringBuilder UsersListString = new StringBuilder();
            UsersListString.Append($"id    Name    Date of birth   Age   Awards  \n");
            foreach (User item in UsersList)
            {
                UsersListString.Append($"{item.ToString()} \n");
            }
            return UsersListString.ToString();
        }
        public static void DataSynchronizationStart()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "yyyy,MM,dd";
            if (!File.Exists("MyData.txt"))
            {
                File.Create("MyData.txt");
            }
            else
            {
                foreach (string line in File.ReadLines("MyData.txt"))
                {
                    string[] myStringArray = line.Split(' ');
                    User newUser = new User
                    {
                        Name = myStringArray[1],
                        DateOfBirth = DateTime.ParseExact(myStringArray[2], format, provider)
                    };
                    int.TryParse(myStringArray[0], out int id);
                    newUser.Id = id;
                    UsersList.Add(newUser);
                    for(int i = 3; i < myStringArray.Length; i++)
                    {
                        newUser.AddAward(myStringArray[i]);
                    }
                }
            }
        }
        public static void DataSynchronizationEnd()
        {
            File.Delete("MyData.txt");
            foreach (User item in UsersList)
            {
                File.AppendAllText("MyData.txt", $"{item.ToString()} \n");
            }
        }
    }
}
