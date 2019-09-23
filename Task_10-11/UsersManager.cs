using System;
using System.Collections.Generic;
using Entities;
using Dependensies;
using System.Text;

namespace Users.BLL
{
    public class UsersManager
    {
        private IUsersStorable UsersStorage = Dependensies.Dependensies.UsersStorage;
        public bool AddUser(User user)
        {
            if (UsersStorage.AddUser(user)) return true;
            else return false;
        }
        public bool RemoveUser(int ID)
        {
            if (UsersStorage.RemoveUser(ID)) return true;
            else return false;
        }
        public bool EditUser(int user_ID, User user)
        {
            if (UsersStorage.EditUser(user_ID, user)) return true;
            else return false;
        }
        public bool AddImage(int user_ID, string path)
        {
            Console.WriteLine("End_00");
            if (UsersStorage.AddImage(user_ID, path)) return true;
            else return false;
        }
        public string GetAwardsString(User user)
        {
            return String.Join(", ", user.Awards.ToArray());
        }
        public ICollection<User> GetAllUsers()
        {
            return UsersStorage.GetAllUsers();
        }
    }
}
